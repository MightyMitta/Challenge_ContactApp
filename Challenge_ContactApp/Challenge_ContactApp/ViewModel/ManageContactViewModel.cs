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
        public RelayCommand EditCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public ObservableCollection<contact> Contacts { get; set; }
        public contactEntities Db { get; set; }

        public ManageContactViewModel()
        {
            CreateCommand = new RelayCommand(Create);
            EditCommand = new RelayCommand(Edit);
            BackCommand = new RelayCommand(Back);
            RemoveCommand = new RelayCommand(Remove);
            Db = new contactEntities();
            Contacts = new ObservableCollection<contact>(Db.contacts.ToList());
        }

        public void Create()
        {
            MessengerInstance.Send(new PageMessage(new NewContact()));
        }

        public void Edit()
        {
            MessageBox.Show("This does not do anything yet");
        }

        public void Remove()
        {
            MessageBox.Show("This does not do anything yet");
        }

        public void Back()
        {
            MessengerInstance.Send(new HistoryMessage());
        }
    }
}
