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
        //De Properties voor de ViewContactViewModel Class
        public RelayCommand<contact> ViewCommand { get; set; }
        public RelayCommand ManageCommand { get; set; }
        public ObservableCollection<contact> Contacts { get; set; }
        public contactDbEntities Db { get; set; }

        //De Constructor voor de ViewContactViewModel Class
        public MenuViewModel(contactDbEntities db)
        {
            ViewCommand = new RelayCommand<contact>(View);
            ManageCommand = new RelayCommand(Manage);
            Db = db;
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
            //De volgende line opent een nieuw window met de gegevens van het geselecteerde Contact
            new ViewContact().Show();
        }

        public void UpdateList()
        {
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
            RaisePropertyChanged("Contacts");
        }
    }
}
