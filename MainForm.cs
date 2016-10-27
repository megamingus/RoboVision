using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMaster
{
    public partial class MainForm : Form
    {
        // Add this variable 
        string RxString;
        ArmCom armCom;
        List<float> xMovement;
        List<float> yMovement;
        List<float> zMovement;
        List<float> MinLimit;
        List<float> MaxLimit;
        List<float> InitialPos;
        float speed = 10;
        float initialZ;
        float maxZ;

        public MainForm()
        {
            InitializeComponent();
            armCom = new ArmCom(serialPort);
            xMovement = new List<float>() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            yMovement = new List<float>() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            zMovement = new List<float>() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            MinLimit = new List<float>() { -45.0f, -45.0f, -45.0f, -90.0f, -90.0f };
            MaxLimit = new List<float>() { 45.0f, 45.0f, 45.0f, 90.0f, 90.0f };
            InitialPos = new List<float>() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            loadConfigurationData();
            armCom.MinLimit = MinLimit;
            armCom.MaxLimit = MaxLimit;
            armCom.InitialPos = InitialPos;
            //armCom.ChangeSpeed(speed);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = ComCombo.SelectedItem.ToString();
            }
            catch (Exception)
            {
                textBox.Text = "Please select a com port.";
                //  return;
                serialPort.PortName = "COM4";

            }

            serialPort.BaudRate = 9600;

            try
            {
                serialPort.Open();
            }
            catch (Exception)
            {

                textBox.Text = "There was a problem with " + serialPort.PortName + ". Did you select the correct one?";
                return;

            }

            if (serialPort.IsOpen)
            {
                ComCombo.Enabled = false;
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                textBox.ReadOnly = false;
                //  armCom.ChangeSpeed(speed);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                ComCombo.Enabled = true;
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                textBox.ReadOnly = true;
            }

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) serialPort.Close();
        }

        private void OnTextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!serialPort.IsOpen) return;

            char[] buffer = new char[1];
            buffer[0] = e.KeyChar;
            loopBoxTxtbox.Text += e.KeyChar;
            serialPort.Write(buffer, 0, 1);

            e.Handled = true;
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox.AppendText(RxString);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = serialPort.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            char carriageReturn = (char)13;
            char[] buffer = new char[1];
            buffer[0] = carriageReturn;
            serialPort.Write(buffer, 0, buffer.Length);
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            armCom.InitConnection();
        }

        private void leftWaist_Click(object sender, EventArgs e)
        {
            //"1;1;EXECJCOSIROP = ( -15.000, 0.000, 0.000, 0.000, 0.000, 0.000)"
            armCom.MoveRelative(-15.2f);
        }

        private void rigthWaist_Click(object sender, EventArgs e)
        {

            //"1;1;EXECJCOSIROP = ( 15.000, 0.000, 0.000, 0.000, 0.000, 0.000)"
            armCom.MoveRelative(15);
        }

        private void rightShoulder_Click(object sender, EventArgs e)
        {
            // "1;1;EXECJCOSIROP = ( 0.000, 10.000, 10.000, 0.000, 0.000, 0.000)"
            armCom.MoveRelative(0, 10, 10);
        }

        private void leftShoulder_Click(object sender, EventArgs e)
        {
            //"1;1;EXECJCOSIROP = ( 0.000, -10.000, -10.000, 0.000, 0.000, 0.000)"
            armCom.MoveRelative(0, -10, -10);
        }

        private void yPos_Click(object sender, EventArgs e)
        {

            //"1;1;EXECJCOSIROP = ( 0.000, -10.000, 10.000, 0.000, 0.000, 0.000)"
            armCom.MoveRelative(0, 0, 10);

        }

        private void yNeg_Click(object sender, EventArgs e)
        {
            // "1;1;EXECJCOSIROP = ( 0.000, 10.000, -10.000, 0.000, 0.000, 0.000)"
            armCom.MoveRelative(0, 0, -10);
        }

        private void initialPos_Click(object sender, EventArgs e)
        {

            // "1;1;EXECJCOSIROP = ( 0.000, 10.000, -10.000, 0.000, 0.000, 0.000)"
            // armCom.InitialPos
            armCom.MoveAbsolute(armCom.InitialPos);
        }

        private void androidConnect_Click(object sender, EventArgs e)
        {
            //  udpSender = new UDPsender(androidIP.Text);
            androidConnect.Enabled = false;

            Task task = new Task(new Action(startServer));
            task.Start();
        }


        private void startServer()
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 29129);
            UdpClient newsock = new UdpClient(ipep);

            IPEndPoint snder = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                data = newsock.Receive(ref snder);
                var msg = Encoding.ASCII.GetString(data, 0, data.Length);
                var msgList = parseString(msg);
                Console.WriteLine("{0}  {1}  {2}", msgList[0], msgList[1], msgList[2]);
                if (initialZ == 0.0f) { initialZ = msgList[2]; maxZ = initialZ; }

                armCom.MoveRelative(Translate(msgList));
                //await Task.Delay(1000);
                //Console.WriteLine(msg);
                // AndroidTxtBox.Text += msg;
                //newsock.Send(data, data.Length, snder);
            }
        }

        private List<float> Translate(List<float> positions)
        {
            var result = new List<float>();
            for (int i = 0; i < 5; i++)
            {
                result.Add(xMovement[i] * positions[0] + yMovement[i] * positions[1] + zMovement[i] * (positions[2] - initialZ));
            }
            return result;
        }

        private List<float> parseString(String text)
        {
            String[] str = text.Split(';');
            int index = 0;
            var x = float.Parse(str[index++].Replace(".", ","));
            var y = float.Parse(str[index++].Replace(".", ","));
            var z = float.Parse(str[index++].Replace(".", ","));
            return new List<float>() { x, y, z };
        }


        public void loadConfigurationData()
        {

            // create reader & open file
            try
            {
                TextReader tr = new StreamReader("config.dat");
                char[] seps = { ':', ';' };
                String line;
                String[] values;

                line = tr.ReadLine();
                values = line.Split(seps);
                MinLimit = new List<float>();
                for (int i = 1; i < values.Length; i++)
                {
                    MinLimit.Add(float.Parse(values[i].Replace(".", ",")));
                }

                line = tr.ReadLine();
                values = line.Split(seps);
                MaxLimit = new List<float>();
                for (int i = 1; i < values.Length; i++)
                {
                    MaxLimit.Add(float.Parse(values[i].Replace(".", ",")));
                }

                line = tr.ReadLine();
                values = line.Split(seps);
                InitialPos = new List<float>();
                for (int i = 1; i < values.Length; i++)
                {
                    InitialPos.Add(float.Parse(values[i].Replace(".", ",")));
                }


                line = tr.ReadLine();
                values = line.Split(seps);
                xMovement = new List<float>();
                for (int i = 1; i < values.Length; i++)
                {
                    xMovement.Add(float.Parse(values[i].Replace(".", ",")));
                }


                line = tr.ReadLine();
                values = line.Split(seps);
                yMovement = new List<float>();
                for (int i = 1; i < values.Length; i++)
                {
                    yMovement.Add(float.Parse(values[i].Replace(".", ",")));
                }


                line = tr.ReadLine();
                values = line.Split(seps);
                zMovement = new List<float>();
                for (int i = 1; i < values.Length; i++)
                {
                    zMovement.Add(float.Parse(values[i].Replace(".", ",")));
                }

                line = tr.ReadLine();
                values = line.Split(seps);
                speed = float.Parse(values[1]);

                // close the stream
                tr.Close();
            }
            catch (System.NullReferenceException)
            {

            }
            catch (System.FormatException)
            {
                //bad config, ignore
                throw new Exception("Config file is mal-formatted.");

            }
            catch (System.IO.FileNotFoundException)
            {
                //no prexsting config, create one with the deafult values

                TextWriter tw = new StreamWriter("config.dat");

                tw.WriteLine("MinAngleLimits: {0}", Format(MinLimit));
                tw.WriteLine("MaxAngleLimits: {0}", Format(MaxLimit));
                tw.WriteLine("InitialPosition: {0}", Format(InitialPos));

                tw.WriteLine("xMovement: {0}", Format(xMovement));
                tw.WriteLine("yMovement: {0}", Format(yMovement));

                tw.WriteLine("zMovement: {0}", Format(zMovement));
                tw.WriteLine("Speed: {0}", speed);


                // close the stream
                tw.Close();

                return;
            }
        }
        private String Format(List<float> angles)
        {
            return string.Format("{0:0}; {1:0}; {2:0}; {3:0}; {4:0}",
               angles[0], angles[1], angles[2], angles[3], angles[4]);
        }

        private void rstbtn_Click(object sender, EventArgs e)
        {
            armCom.ResetAlarm();
        }

    }
}