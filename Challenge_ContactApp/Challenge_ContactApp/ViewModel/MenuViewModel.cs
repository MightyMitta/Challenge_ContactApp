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

namespace Challenge_ContactApp.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public RelayCommand<contact> ViewCommand { get; set; }
        public RelayCommand ManageCommand { get; set; }
        public ObservableCollection<contact> Contacts { get; set; }
        public contactDbEntities Db { get; set; }


        public MenuViewModel()
        {
            ViewCommand = new RelayCommand<contact>(View);
            ManageCommand = new RelayCommand(Manage);
            Db = new contactDbEntities();
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
            MessengerInstance.Register<UpdateMessage>(this, Message => UpdateList());
        }

        public void Manage()
        {
            MessengerInstance.Send(new PageMessage(new ManageContact()));
        }

        public void View(contact contact)
        {
            MessengerInstance.Send<ContactMessage>(new ContactMessage(contact));
            new ViewContact().Show();
        }

        public void UpdateList()
        {
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
            RaisePropertyChanged("Contacts");
        }
    }
}
