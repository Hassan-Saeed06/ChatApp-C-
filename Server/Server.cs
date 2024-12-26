using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using SerialiazeDeserialize;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace Server
{
    
    public class Server
    {
        //static void PrintFrames(string operationType, NetMQMessage message)
        //{
        //    for (int i = 0; i < message.FrameCount; i++)
        //    {
        //        Console.WriteLine("{0} Socket : Frame[{1}] = {2}", operationType, i,
        //            message[i].ConvertToString());
        //    }
        //}
        public class UserData
        {
            public string username { get; set; }
            public string id { get; set; }

        }
        static List<string> LS_Status = new List<string>();
        static List<string> LS_Status_Email = new List<string>();

        static List<UserData> UserInfo = new List<UserData>();
        
        public static string MessageHanlder(string message_resrcv)
        {
            
            //int i = 1;
            string json = "";

            //while (true)
            //{
            Console.WriteLine("In Server");
            //string message_resrcv = ServerSocketLayer.ServerSocketLayer.ServerSocket();

            //using (var response = new ResponseSocket("tcp://*:5555"))
            //{

            //var message_resrcv = "";
            //message_resrcv = response.ReceiveFrameString();                                 /////////////////////   Receiving from Client


            SerializeDeserialize sd = new SerializeDeserialize();
            var res = sd.DeSeriliaze1(message_resrcv);                                     /////////////////////   Deserialzing the object receive from Client


            if (res[2] == "Login")
            {
                string email = res[0];
                string pass = res[1];
                //string guid = res[3];

                List<string> LS = new List<string>();
                       
                if (!LS_Status_Email.Contains(email) || LS_Status_Email.Count == 0)
                {
                    LS = Verification.Verification.verify(email, pass);
                    //LS = Verification.Verification.verify(email, pass, guid);

                    //LS.Add(guid);

                    SerializeDeserialize sd1 = new SerializeDeserialize();
                    json = sd1.Seriliaze1(LS);                                                   /////////////////////   Serializing the object
                    //response.SendFrame(json);

                    if (LS[0] == "true")
                    {
                        UserInfo.Add(new UserData()
                        {

                            username = LS[1],
                            id = LS[2]


                        });
                        LS_Status.Add(LS[1]);
                        LS_Status_Email.Add(email);
                    }
            
                    //LS_Status = Status.Status.status(LS[1]);

                    foreach (string s in LS_Status)
                    {
                        Console.WriteLine("Online: " + s);
                    }
                }
                else
                {
                    LS.Add("Already SignedIn");
                    LS.Add(res[0].ToString());

                    SerializeDeserialize sd1 = new SerializeDeserialize();
                    json = sd1.Seriliaze1(LS);                                                   /////////////////////   Serializing the object
                    //response.SendFrame(json); return
                }
 

            }

            if(res[2]=="Refresh")
            {
                //List<string> OnlineList = new List<string>();
                //OnlineList.Add(LS_Status.ToString());
                ////OnlineList.Add(LS_Status.Count.ToString());
                //OnlineList.Insert(0, OnlineList.Count.ToString());
                UserInfo.Insert(0, new UserData() { id = UserInfo.Count.ToString(), username="Count" });

                //UserInfo.Insert(0, UserInfo.Count.ToString());
                LS_Status.Insert(0, LS_Status.Count.ToString());

                SerializeDeserialize sd1 = new SerializeDeserialize();
                //string json = sd1.Seriliaze1(OnlineList);                                                   /////////////////////   Serializing the object

                //json = sd1.Seriliaze1(LS_Status);                                                   /////////////////////   Serializing the object
                json = sd1.Seriliaze1(UserInfo);                                                   /////////////////////   Serializing the object

                //response.SendFrame(json);  return

                Console.WriteLine("Deleivered");
                LS_Status.RemoveAt(0);
                UserInfo.RemoveAt(0);


                //OnlineList.RemoveAt(0);
                //Console.WriteLine("Removed");
            }
            if (res[0] == "Message")
            {
                List<string> _data = new List<string>();

                string FromclientID = res[1];
                string TOClientID = res[2];
                string message = res[3];
                _data.Add(FromclientID);              //// from clientID
                _data.Add(TOClientID);              //// TO clientID       
                _data.Add(message);                  /// Message from CLIENTID   
                        

                //////////////////          SERIALIZE_DERSERIALIZE    ///////////////////

                SerializeDeserialize sd2 = new SerializeDeserialize();
                json = sd2.Seriliaze1(_data);
                //response.SendFrame(json); return
            }


            //}//socket_using
                
                
                

            //Thread.Sleep(3000);
            return json;
            //}//while
        }
        public static void Main(string[] args)
        {

           
            ////////////////////////////////////////////////////////////       MAIN CODE       /////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            





            //////////////////////////////////////////////////////////       MAIN CODE       /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }//main_function
    }//Class Server


}
