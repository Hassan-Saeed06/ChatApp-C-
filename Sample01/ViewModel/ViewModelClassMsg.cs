using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Sample01.Model;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using NetMQ.Sockets;
using NetMQ;
using System.Threading;
using System.Collections.ObjectModel;

namespace Sample01.ViewModel
{
    class ViewModelClassMsg : INotifyPropertyChanged
    {

        private ModelClassMsg m1 = new ModelClassMsg();
        string msg;


        public RelayCommand AddNew { get; set; }

        private string _msg1;

        public string MessageArgument
        {

            get { return this._msg1; }
            set
            {
                this._msg1 = value;
                this.m1.msg = msg;

                
                this.onpropertychanged("MessageArgument");

            }
        }

        

        private string _msg_rcv1;

        //private ObservableCollection<ModelClassMsg> _message_list;
        //public ObservableCollection<ModelClassMsg> MessageList
        //{
        //    get
        //    {
        //        return _message_list;
        //    }
        //    set
        //    {
        //        _message_list = value;
        //        onpropertychanged("MessageList");
        //    }
        //}

        public string AddedArgument
        {
            get { return this._msg_rcv1; }
            set
            {
                this._msg_rcv1 = value;
                this.onpropertychanged("Addedargument");
            }
        }

        public ViewModelClassMsg()
        {

            AddNew = new RelayCommand(MessageSend);
            //MessageList = new ObservableCollection<ModelClassMsg>();
        }

        private void MessageSend()
        {
            var a = this.MessageArgument;
            //console.writeline("message send!");
            //MessageBox.Show(a);
            AddedArgument = a;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onpropertychanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}

