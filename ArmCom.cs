using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Text;

namespace MoveMaster
{
    class ArmCom
    {
        SerialPort serialPort;
        public String speed { get; private set; }

        public List<float> MaxLimit { get; set; }
        public List<float> MinLimit { get; set; }
        public List<float> InitialPos { get; set; }
        public List<float> currentPos { get; private set; }

        public ArmCom(SerialPort serialPort, float speed = 50.0f)
        {
            this.serialPort = serialPort;
            this.speed = String.Format("{0:0.0}", speed);

            //waist shoulder elbow pitch roll
            MinLimit = new List<float>() { -45.0f, -45.0f, -45.0f, -90.0f, -90.0f };
            MaxLimit = new List<float>() { 45.0f, 45.0f, 45.0f, 90.0f, 90.0f };
            currentPos = new List<float>() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            InitialPos = new List<float>() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
        }


        public void SendCommand(String command)
        {
            SendCommands(new List<String>() { command });
        }

        public void SendCommands(List<String> commands)
        {
            char[] myArray = new char[1] { (char)13 };
            commands.ForEach(x =>
            {
                try{
                    serialPort.Write(x.ToCharArray(), 0, x.ToCharArray().Length);
                    serialPort.Write(myArray, 0, myArray.Length);
                    Console.WriteLine(x);
                }catch(Exception)
                {
                    Console.WriteLine(x);
                }
            });

            Console.WriteLine("Current position: {0}", Format(currentPos));
            Console.WriteLine();
        }

        public void ResetAlarm()
        {
            List<String> rst = new List<String>() {
                 "1;1;CNTLOFF"              //apago el control
                , "1;1;RSTALRM"             //reset alarm
                , "1;1;SRVON"               //servo on
                , "1;1;STATE"               //pregunto el estado... solo para saber
                , "1;1;CNTLON"              //control on
                };
            SendCommands(rst);
        }

        public void InitConnection()
        {
            List<String> initArm = new List<String>() {
                "1;1;OPEN=NARCUSR"
                , "1;1;PARRLNG"
                , "1;1;PDIRTOP"
                , "1;1;PPOSF"
                , "1;1;PARMEXTL"
                , "1;1;KEYWDptest"
                , "1;1;SRVON"               //servo on
                , "1;1;RSTALRM"             //reset alarm
                , "1;1;STATE"
                , "1;1;CNTLON"               //control on
                //, "1;1;EXECJOVRD 45,0"     //Velocidad
                };
            SendCommands(initArm);
            MoveAbsolute(InitialPos); //initial position
        }

        public void ChangeSpeed(float speed)
        {
            this.speed = String.Format("{0:0.0}", speed);
            SendCommand("1;1;EXECJOVRD " + this.speed);     //Velocidad
        }

        public void MoveAbsolute(List<float> angles)
        {
            VerifyMovement(angles, false);
        }

        public void MoveRelative(List<float> angles)
        {
            VerifyMovement(angles, true);
        }

        public void MoveAbsolute(float waist = 0.0f, float shoulder = 0.0f, float elbow = 0.0f, float pitch = 0.0f, float roll = 0.0f)
        {
            VerifyMovement(new List<float>() { waist, shoulder, elbow, pitch, roll }, false);
        }

        public void MoveRelative(float waist = 0.0f, float shoulder = 0.0f, float elbow = 0.0f, float pitch = 0.0f, float roll = 0.0f)
        {
            VerifyMovement(new List<float>() { waist, shoulder, elbow, pitch, roll }, true);
        }

        void VerifyMovement(List<float> angles, bool moveRelatvie = true)
        {
            for (var i = 0; i < angles.Count; i++)
            {
                currentPos[i] = Math.Min(Math.Max(moveRelatvie ? currentPos[i] + angles[i] : angles[i], MinLimit[i]), MaxLimit[i]);
            }
            var point = Format(currentPos);
            MoveArm(point);
        }

        private String Format(List<float> angles)
        {
            return string.Format("( {0:0.000}; {1:0.000}; {2:0.000}; {3:0.000}; {4:0.000} )",
               angles[0], angles[1], angles[2], angles[3], angles[4]).Replace(",", ".").Replace(";", ","); ;
        }

        //angles=( -15.000, 0.000, 0.000, 0.000, 0.000, 0.000)
        private void MoveArm(String angles)
        {
            List<String> command2Send = new List<String>() { //"1;1;CNTLON", "1;1;EXECJOVRD 46.3",
                                                            "1;1;EXECJCOSIROP = "+angles
                                                            ,"1;1;EXECMOV JCOSIROP"
                                                            //,"1;1;EXECMOV "+ (moveRelative?"J_CURR + JCOSIROP":"JCOSIROP")
                                                           //,"1;1;CNTLOFF."
                                                                };
            SendCommands(command2Send);
        }
    }
}
