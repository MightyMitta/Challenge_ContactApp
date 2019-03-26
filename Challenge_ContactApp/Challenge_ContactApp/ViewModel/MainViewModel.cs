using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Challenge_ContactApp.Messenger;
using Challenge_ContactApp.View;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Challenge_ContactApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Page _currentPage;

        //Stack is a list where you can add and remove the first item using ExampleStack.Push() or ExampleStack.Pop()
        public Stack<Page> History { get; set; }
        public Page PreviousPage { get; set; }
        public Page CurrentPage { get { return _currentPage; } set { _currentPage = value; } }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand CloseAppCommand { get; set; }


        //The MainViewModel Constructor will run the code in it when the app is started
        public MainViewModel()
        {
            History = new Stack<Page>();
            CurrentPage = new View.Menu();
            MessengerInstance.Register<PageMessage>(this, Message => SwitchPage(Message));
            MessengerInstance.Register<HistoryMessage>(this, Message => PageBack());
            CloseAppCommand = new RelayCommand(CloseApp);
        }

        //The SwitchPage method will add a page to the History Stack and switches to the selected page
        public void SwitchPage(PageMessage pageMessage)
        {
            if (CurrentPage.GetType() == pageMessage.Page.GetType())
            {
                return;
            }
            History.Push(CurrentPage);
            CurrentPage = pageMessage.Page;
            RaisePropertyChanged("CurrentPage");
        }

        //The PageBack method will remove the first item from the History Stack and go to the previous page
        public void PageBack()
        {
            CurrentPage = History.Pop();
            RaisePropertyChanged("CurrentPage");
        }

        //The CloseApp method will close the App when called
        public void CloseApp()
        {
            ;
        }
    }
}