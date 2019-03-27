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
using System.Data.Entity;

namespace Challenge_ContactApp.ViewModel
{
    public class EditContactViewModel : ViewModelBase
    {
        private contact _contact;

        //De properties voor de EditContactViewModel Class
        public contact Contact { get { return _contact; } set { _contact = value; } }
        public RelayCommand EditUserCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public contactDbEntities Db { get; set; }
        public string SelectedContact { get { return "Edit " + Contact.firstname; } }

        //De Constructor voor de EditConactViewModel Class.
        public EditContactViewModel(contactDbEntities db)
        {
            MessengerInstance.Register<ContactMessage>(this, message => UpdateContact(message.Contact));
            EditUserCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
            Db = db;
        }

        public void Edit()
        {
            try
            {
                Db.contacts.Attach(Contact);
                Db.Entry(Contact).State = EntityState.Modified;
                Db.SaveChanges();
                MessageBox.Show($"{Contact.firstname} has been edited.", "Edit Succesful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                MessengerInstance.Send(new HistoryMessage());
            }
            catch
            {
                MessageBox.Show($"Could not edit {Contact.firstname}!", "Failed to edit contact", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                MessengerInstance.Send(new HistoryMessage());
            }
        }

        public void Back()
        {
            Db.Entry(Contact).Reload();
            MessengerInstance.Send(new UpdateMessage());
            MessengerInstance.Send(new HistoryMessage());
        }

        public void UpdateContact(contact contact)
        {
            Contact = contact;
            RaisePropertyChanged("Contact");
        }
    }
}