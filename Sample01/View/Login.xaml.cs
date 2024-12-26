using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NetMQ;
using NetMQ.Sockets;
using Sample01.Model;


namespace Sample01
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        //static string connectionString = @"Data Source=DEV-HASSANSAEED;Initial Catalog=Login; Integrated Secutiry=True";
        //static String connectionString = @"Data Source=192.168.0.192;Initial Catalog=Login;User ID=sa;Password=1234;";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            string message = "Invalid Credentials";
            //string message_invalid = "Invalid Credentials";
            try
            {
                con = new SqlConnection(@"Data Source=DEV-HASSANSAEED;Initial Catalog=Login; Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("Select * from tblCustomerInfo where CustomerEmail=@CustomerEmail", con);
                Console.WriteLine("Cmd Para: " + cmd.Parameters.AddWithValue("@CustomerEmail", txtUserId.Text.ToString()));
                Console.WriteLine("cmd" + cmd);
                reader = cmd.ExecuteReader();
                Console.WriteLine("Reader: " + reader);
                Console.WriteLine("***");

                if (reader.Read())

                {


                    using (var response = new ResponseSocket("tcp://*:5555"))
                    using (var request = new RequestSocket("tcp://localhost:5555"))
                    {
                        request.SendFrame(reader["Password"].ToString());

                        var message_resrcv = response.ReceiveFrameString();
                        Console.WriteLine("\nReceived: " + message);



                        if (message_resrcv.Equals(txtPassword.Password.ToString(), StringComparison.InvariantCulture))
                        {
                            var msg = "1";
                            response.SendFrame(msg);
                            message = request.ReceiveFrameString();
                            Console.WriteLine("Message: " + message);
                            ModelClassMsg.CustomerEmail = txtUserId.Text.ToString();
                            ModelClassMsg.CustomerName = reader["CustomerName"].ToString();
                        }
                    }

                }
                reader.Close();
                reader.Dispose();

                
                cmd.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
            if (message == "1")
            {
                MessageBox.Show("Login Successfull");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Login login = new Login();
                login.Show();
                this.Close();

            }
            else
                MessageBox.Show(message, "Info");
        }


        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


