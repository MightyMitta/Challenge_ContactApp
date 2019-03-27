using Challenge_ContactApp.Model;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_ContactApp.Messenger
{
    public class ContactMessage : MessageBase
    {
        public contact Contact { get; set; }

        public ContactMessage(contact contact)
        {
            Contact = contact;
        }
    }
}
