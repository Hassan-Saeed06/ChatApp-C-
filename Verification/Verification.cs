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
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;

namespace Verification
{
    public class Verification
    {
        public static List<string> verify (string email, string pass)
        {
            //string email = res[0].ToString();
            //string pass = res[1].ToString();
            string select_query = "Select * from tblCustomerInfo where CustomerEmail=@CustomerEmail";
            List <string>  LS = new List<string>();
            
            LS = DataLayer.DataLayer.query(select_query, email, pass);


            //SqlConnection con;
            //SqlCommand cmd;
            //SqlCommand cmd1;
            //SqlDataReader reader;
            ////List<string> LS = new List<string>();
            //try
            //{
            //    con = new SqlConnection(@"Data Source=DEV-HASSANSAEED;Initial Catalog=Login; Integrated Security=True");
            //    con.Open();
            //    cmd = new SqlCommand("Select * from tblCustomerInfo where CustomerEmail=@CustomerEmail", con);
            //    //cmd1 = new SqlCommand("Update tblCustomerInfo set Guid=12344675 WHERE CustomerEmail=hassan.saeed@logiciel.com;", con);
            //    Console.WriteLine("Cmd Para: " + cmd.Parameters.AddWithValue("@CustomerEmail", email));
            //    Console.WriteLine("cmd" + cmd);
            //    reader = cmd.ExecuteReader();
            //    Console.WriteLine("Reader: " + reader);
            //    Console.WriteLine("***");

            //    if (reader.Read())
            //    {

            //        //if (message_resrcv.Equals(LS[1], StringComparison.InvariantCulture))
            //        if (reader["Password"].ToString().Equals(pass, StringComparison.InvariantCulture))
            //        {
            //            //cmd.Parameters.Clear();
            //            //cmd = new SqlCommand("Update tblCustomerInfo set Guid=12344675 WHERE CustomerEmail=hassan.saeed@logiciel.com;", con);
            //            //cmd.Parameters.AddWithValue("@Guid", guid);
            //            //cmd.Parameters.AddWithValue("@CustomerEmail", email);
            //            //cmd.ExecuteNonQuery();

            //            //List<string> LS = new List<string>();
            //            LS.Add("true");
            //            LS.Add(reader["CustomerName"].ToString());
            //            reader.Close();
            //            reader.Dispose();

            //            cmd1 = new SqlCommand("UPDATE tblCustomerInfo SET Guid =@Guid Where CustomerEmail=@CustomerEmail", con);
            //            cmd1.Parameters.AddWithValue("@CustomerEmail", email);
            //            cmd1.Parameters.AddWithValue("@Guid", guid);
            //            //cmd1.CommandText = "UPDATE tblCustomerInfo SET Guid = 123456789 Where CustomerEmail = hassan01saeed@logiciel.com  ";
            //            cmd1.ExecuteNonQuery();
            //            cmd1.Dispose();

            //            //LS.Add(guid);


            //            SerializeDeserialize sd1 = new SerializeDeserialize();
            //            string json = sd1.Seriliaze1(LS);                                                   /////////////////////   Serializing the object


            //            Console.WriteLine("Executed");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Inexception");
            //            LS.Add("Invalid");
            //            LS.Add(reader["CustomerName"].ToString());
            //            SerializeDeserialize sd1 = new SerializeDeserialize();
            //            string json = sd1.Seriliaze1(LS);                                                   /////////////////////   Serializing the object
            //            reader.Close();
            //            reader.Dispose();


            //            //response.SendFrame(json);
            //        }

            //    }
            //    //reader.Close();
            //    //reader.Dispose();


            //    //cmd.Parameters.AddWithValue("@CustomerEmail", email);








            //    cmd.Dispose(); 

            //    con.Close();

            //}
            //catch (Exception ex)
            //{
            //    throw;

            //}
            return LS;



        }

        public static void Main(string[] args)
        {
            //List<string> n = verify("","");
        }
    }
}
