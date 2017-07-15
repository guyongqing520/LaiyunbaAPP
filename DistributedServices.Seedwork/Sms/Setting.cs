using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedServices.Seedwork.Sms
{
    public class Setting
    {
        private static string _smsUrl = "http://v.juhe.cn/sms/send";
        private static string _port = "";
        private static string _userKey = "e9acd2476e54d5c055e0baca37a65b43";    
        private static string _account = "";   
        private static string _password = "";     
        private static string _mobile = "";   
        private static string _content = "";   
        private static string _sendTime = "";    
        private static string _action = "";   
        private static string _extno = "";
        private static string _dtype = "xml";


        public static string SmsUrl
        {
            get { return Setting._smsUrl; }
            set { Setting._smsUrl = value; }
        }
        public static string Port
        {
            get { return Setting._port; }
            set { Setting._port = value; }
        }
        public static string UserKey
        {
            get { return Setting._userKey; }
            set { Setting._userKey = value; }
        }
        public static string Account
        {
            get { return Setting._account; }
            set { Setting._account = value; }
        }
        public static string Password
        {
            get { return Setting._password; }
            set { Setting._password = value; }
        }
        public static string Mobile
        {
            get { return Setting._mobile; }
            set { Setting._mobile = value; }
        }
        public static string Content
        {
            get { return Setting._content; }
            set { Setting._content = value; }
        }
        public static string SendTime
        {
            get { return Setting._sendTime; }
            set { Setting._sendTime = value; }
        }
        public static string Action
        {
            get { return Setting._action; }
            set { Setting._action = value; }
        }
        public static string Extno
        {
            get { return Setting._extno; }
            set { Setting._extno = value; }
        }
        public static string Dtype
        {
            get { return Setting._dtype; }
            set { Setting._dtype = value; }
        }

    }
}
