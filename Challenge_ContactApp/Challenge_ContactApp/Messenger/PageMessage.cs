using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Challenge_ContactApp.Messenger
{
    public class PageMessage : MessageBase
    {
        public Page Page { get; }

        public PageMessage(Page page)
        {
            Page = page;
        }
    }
}
