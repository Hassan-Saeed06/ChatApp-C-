using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace ServerSocketLayer
{
    public class ServerSocketLayer
    {
        //public static void ServerSocket()
        //{
            

        //    //return ""; 
        //}

        public static void Main(string[] args)
        {
            while (true)
            {
                using (var response = new ResponseSocket("tcp://*:5555"))
                {
                    var message_resrcv = "";
                    message_resrcv = response.ReceiveFrameString();                                 /////////////////////   Receiving from Client

                    string json = Server.Server.MessageHanlder(message_resrcv);

                    response.SendFrame(json);

                }
                Thread.Sleep(3000);
            }
        }
    }
}
