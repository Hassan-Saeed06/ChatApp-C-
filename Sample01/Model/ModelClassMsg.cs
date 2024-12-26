using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Sample01.Model
{
    //class ModelClassMsg : INotifyPropertyChanged
    public class ModelClassMsg
    {
        public string msg
        { get; set; }

        public string msg_rcv
        { get; set; }

        //private string msg;
        //public string Message
        //{
        //    get { return msg; }
        //    set
        //    {
        //        msg = value;
        //        OnPropertyChanged(Message);
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string p)
        //{
        //    PropertyChangedEventHandler ph = PropertyChanged;
        //    if (ph != null)
        //    {
        //        ph(this, new PropertyChangedEventArgs(p.ToString()));
        //    }
        //}

        public static String CustomerName = "";
        public static String CustomerEmail = "";

    }

}
