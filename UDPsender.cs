using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace SimpleSerial
{
    class UDPsender
    {

        // Esta clase se encarga de la comunicacion con Unity


        private Socket sock;
        private IPEndPoint endPoint;
        private String serverip;

        //private static readonly UDPsender instance = new UDPsender();

        //public static UDPsender Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

     //   static UDPsender() { }

        //private UDPsender() {
        public UDPsender(String serverip = "127.0.0.1") {


            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse(serverip);
          //  IPAddress serverAddr = IPAddress.Parse("192.168.1.145");
            endPoint = new IPEndPoint(serverAddr, 29129);
        }



        public void send(String msg)
        {
            string text = msg;
            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);

            //Console.WriteLine(msg);

            EndPoint Remote = (EndPoint)endPoint;
            byte[] data = new byte[1024];
            int receivedDataLength = sock.ReceiveFrom(data,ref Remote);

            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, receivedDataLength));
        }
    }
}
