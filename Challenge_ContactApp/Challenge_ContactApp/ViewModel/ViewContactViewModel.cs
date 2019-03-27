using Challenge_ContactApp.Messenger;
using Challenge_ContactApp.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_ContactApp.ViewModel
{
    public class ViewContactViewModel : ViewModelBase
    {
        //De properties voor de ViewContactViewModel Class
        public contact Contact { get; set; }

        //De Constructor voor de ViewContactViewModel Class.
        public ViewContactViewModel()
        {
            MessengerInstance.Register<ContactMessage>(this, message => UpdateContact(message.Contact));
        }

        public void UpdateContact(contact contact)
        {
            Contact = contact;
            RaisePropertyChanged("Contact");
        }
    }
}
