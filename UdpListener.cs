using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace SimpleSerial
{
    public struct Received
    {
        public IPEndPoint Sender;
        public string Message;
    }

    //abstract class UdpBase
    //{
    //    protected UdpClient Client;

    //    protected UdpBase()
    //    {
    //        Client = new UdpClient();
    //    }

    //    public async Task<Received> Receive()
    //    {
    //        var result = await Client.ReceiveAsync();
    //        return new Received()
    //        {
    //            Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
    //            Sender = result.RemoteEndPoint
    //        };
    //    }
    //}
    ////Server
    //class UdpListener : UdpBase
    //{
    //    private IPEndPoint _listenOn;

    //    public UdpListener()
    //        : this(new IPEndPoint(IPAddress.Any, 32123))
    //    {
    //    }

    //    public UdpListener(IPEndPoint endpoint)
    //    {
    //        _listenOn = endpoint;
    //        Client = new UdpClient(_listenOn);
    //    }

    //    public void Reply(string message, IPEndPoint endpoint)
    //    {
    //        var datagram = Encoding.ASCII.GetBytes(message);
    //        Client.Send(datagram, datagram.Length, endpoint);
    //    }

    //}
}
