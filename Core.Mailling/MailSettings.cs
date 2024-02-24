﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailling
{
    public class MailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderFullName { get; set; }
        public string SenderEmail   { get; set;}
        public string UserName { get; set;}
        public string Password { get; set;}

        public MailSettings()
        {
            
        }

        public MailSettings(string server, int port, string senderFullName, string senderEmail, string userName, string password)
        {
            Server = server;
            Port = port;
            SenderFullName = senderFullName;
            SenderEmail = senderEmail;
            UserName = userName;
            Password = password;
        }
    }
}
