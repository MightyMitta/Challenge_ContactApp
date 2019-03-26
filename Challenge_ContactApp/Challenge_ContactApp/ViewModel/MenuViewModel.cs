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
        public RelayCommand ManageCommand { get; set; }
        public ObservableCollection<contact> Contacts { get; set; }
        public contactEntities Db { get; set; }


        public MenuViewModel()
        {
            ManageCommand = new RelayCommand(Manage);
            Db = new contactEntities();
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
        }

        public void Manage()
        {
            MessengerInstance.Send(new PageMessage(new ManageContact()));
        }
    }
}
