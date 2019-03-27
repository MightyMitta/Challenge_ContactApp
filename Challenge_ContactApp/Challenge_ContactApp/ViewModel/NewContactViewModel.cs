using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_ContactApp.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using Challenge_ContactApp.Messenger;

namespace Challenge_ContactApp.ViewModel
{
    public class NewContactViewModel : ViewModelBase
    {
        private contact _contact;

        public contact Contact { get { return _contact; } set { _contact = value; } }
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public contactDbEntities Db { get; set; }

        public NewContactViewModel()
        {
            Contact = new contact();
            Contact.address = new address();
            AddUserCommand = new RelayCommand(AddUser);
            BackCommand = new RelayCommand(Back);
            Db = new contactDbEntities();
        }

        public void AddUser()
        {
            //try
            //{
            Db.contacts.Add(Contact);
            Db.SaveChanges();
            MessageBox.Show($"Contact {Contact.firstname} has been added!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            MessengerInstance.Send(new UpdateMessage());
            MessengerInstance.Send(new HistoryMessage());
            Contact = new contact();
            Contact.address = new address();
            //}
            //catch
            //{
            MessageBox.Show("Could not add Contact!", "Failed to add Contact", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //}
        }

        public void Back()
        {
            MessengerInstance.Send(new HistoryMessage());
            Contact = new contact();
            Contact.address = new address();
        }
    }
}
