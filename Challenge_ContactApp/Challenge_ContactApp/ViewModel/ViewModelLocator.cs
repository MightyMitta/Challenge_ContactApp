using Challenge_ContactApp.Model;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Challenge_ContactApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<contactDbEntities>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<NewContactViewModel>();
            SimpleIoc.Default.Register<ManageContactViewModel>();
            SimpleIoc.Default.Register<EditContactViewModel>(true);
            SimpleIoc.Default.Register<ViewContactViewModel>(true);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MenuViewModel Menu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public ManageContactViewModel ManageContact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManageContactViewModel>();
            }
        }

        public NewContactViewModel NewContact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewContactViewModel>();
            }
        }

        public EditContactViewModel EditContact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditContactViewModel>();
            }
        }

        public ViewContactViewModel ViewContact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewContactViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}