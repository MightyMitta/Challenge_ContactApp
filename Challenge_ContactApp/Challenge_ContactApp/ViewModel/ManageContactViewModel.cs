using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Challenge_ContactApp.Messenger;
using Challenge_ContactApp.Model;
using Challenge_ContactApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Challenge_ContactApp.ViewModel
{
    public class ManageContactViewModel : ViewModelBase
    {
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand<contact> EditCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand<contact> RemoveCommand { get; set; }
        public ObservableCollection<contact> Contacts { get; set; }
        public contactDbEntities Db { get; set; }

        public ManageContactViewModel(contactDbEntities db)
        {
            CreateCommand = new RelayCommand(Create);
            EditCommand = new RelayCommand<contact>(Edit);
            BackCommand = new RelayCommand(Back);
            RemoveCommand = new RelayCommand<contact>(Remove);
            Db = db;
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
            MessengerInstance.Register<UpdateMessage>(this, Message => UpdateList());
        }

        public void Create()
        {
            MessengerInstance.Send(new PageMessage(new NewContact()));
        }

        public void Edit(contact contact)
        {
            MessengerInstance.Send(new ContactMessage(contact));
            MessengerInstance.Send(new PageMessage(new EditContact()));
        }

        public void Remove(contact contact)
        {
            try
            {
                MessageBox.Show($"{contact.firstname} has been removed.", "Remove Succesful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Db.addresses.Remove(contact.address);
                Db.contacts.Remove(contact);
                Db.SaveChanges();
                MessengerInstance.Send(new UpdateMessage());
            }
            catch
            {
                MessageBox.Show($"Could not remove {contact.firstname}!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Back()
        {
            MessengerInstance.Send(new HistoryMessage());
        }

        public void UpdateList()
        {
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
            RaisePropertyChanged("Contacts");
        }
    }
}
