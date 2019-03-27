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
    public class EditContactViewModel : ViewModelBase
    {
        private contact _contact;

        public contact Contact { get { return _contact; } set { _contact = value; } }
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public contactDbEntities Db { get; set; }
        public string SelectedContact { get { return "Edit " + Contact.firstname; } }


        public EditContactViewModel()
        {
            MessengerInstance.Register<ContactMessage>(this, message => UpdateContact(message.Contact));
            AddUserCommand = new RelayCommand(AddUser);
            BackCommand = new RelayCommand(Back);
            Db = new contactDbEntities();
        }

        public void AddUser()
        {
            try
            {
                var res = Db.contacts.SingleOrDefault(contact => contact.contact_id == Contact.contact_id);

                if (res != null)
                {
                    res = Contact;
                    Db.SaveChanges();
                    MessageBox.Show($"{Contact.firstname} has been edited.", "Edit Succesful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    MessengerInstance.Send(new HistoryMessage());
                }
            }
            catch
            {
                MessageBox.Show($"Could not edit {Contact.firstname}!", "Failed to edit contact", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                MessengerInstance.Send(new HistoryMessage());
            }
        }

        public void Back()
        {
            MessengerInstance.Send(new HistoryMessage());
        }

        public void UpdateContact(contact contact)
        {
            Contact = contact;
            RaisePropertyChanged("Contact");
        }
    }
}
