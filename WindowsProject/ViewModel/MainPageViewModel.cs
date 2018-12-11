using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsProject.View;

namespace WindowsProject.ViewModel
{
   public class MainPageViewModel : ViewModelBase
    {
        public RelayCommand AllOndernemingenCommand { get; set; }
        public RelayCommand RestaurantsCommand { get; set; }
        public RelayCommand BarsCommand { get; set; }
        public RelayCommand OvernachtingCommand { get; set; }
        public RelayCommand AndereCommand { get; set; }
        public RelayCommand KledingCommand { get; set; }
        public RelayCommand KappersCommand { get; set; }
        public RelayCommand NavigateToDetailCommand { get; set; }
        public RelayCommand SignInCommand { get; set; }
        public RelayCommand RegistreerGebruikerCommand { get; set; }
        public RelayCommand RegistreerOndernemerCommand { get; set; }
        public RelayCommand VoegEventToeCommand { get; set; }
        public RelayCommand VoegPromotieToeCommand { get; set; }
        public RelayCommand NaarAbonnementenCommand { get; set; }



        public MainPageViewModel()
        {
            ShowOndernemingen(); //toon de ondernemingen direct
            AllOndernemingenCommand = new RelayCommand(_ => ShowOndernemingen());
            BarsCommand = new RelayCommand(_ => showBars());
            RestaurantsCommand = new RelayCommand(_ => showRestaurants());
            OvernachtingCommand = new RelayCommand(_ => showOvernachting());
            AndereCommand = new RelayCommand(_ => showAndere());
            KledingCommand = new RelayCommand(_ => showKleding());
            KappersCommand = new RelayCommand(_ => showKappers());
            SignInCommand = new RelayCommand(async _ => await showLoginAsync());
            RegistreerGebruikerCommand = new RelayCommand(async _ => await showRegistreerGebruikerAsync());
            RegistreerOndernemerCommand = new RelayCommand(async _ => await showRegistreerOndernemerAsync());
            VoegEventToeCommand = new RelayCommand( _ => showEvent());
            VoegPromotieToeCommand = new RelayCommand( _ => showPromotie());
            NaarAbonnementenCommand = new RelayCommand( _ => showAbonnementen());



        }

        private void showAbonnementen()
        {
            throw new NotImplementedException();
        }

        private void showPromotie()
        {
            CurrentData = new PromotieViewModel(this);
        }

        private void showEvent()
        {
            CurrentData = new EventViewModel(this);
        }

        private async Task showRegistreerOndernemerAsync()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 1;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(RegistreerAlsOndernemer), null);
                frame.DataContext = new RegistreerAlsOndernemerViewModel();
                //Page page = new Page();

                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
         //   CurrentData = new RegistreerAlsOndernemerViewModel();
        }

        private async Task showRegistreerGebruikerAsync()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 1;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(RegistreerAlsGebruiker), null);
                frame.DataContext = new RegistreerAlsGebruikerViewModel();
                //Page page = new Page();

                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private async Task showLoginAsync()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            ApplicationView newAppView = null;
            int newViewId = ApplicationView.GetApplicationViewIdForWindow(
    CoreApplication.MainView.CoreWindow);
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                /*Frame frame = new Frame();
                frame.Navigate(typeof(SignIn), null);*/
                //Page page = new Page();
                newAppView = ApplicationView.GetForCurrentView();
                Window.Current.Content = new SignIn();
                // You have to activate the window in order to show it later.
                Window.Current.Activate();
                //newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id,
    ViewSizePreference.UseHalf,
    newViewId,
    ViewSizePreference.UseHalf);
        }

        private void showKappers()
        {
            CurrentData = new LijstViewModel(this,"Kapper");
        }

        private void showKleding()
        {
            CurrentData = new LijstViewModel(this,"Kleding");
        }

        private void showAndere()
        {
            CurrentData = new LijstViewModel(this,"Andere");
        }

        private void showOvernachting()
        {
            CurrentData = new LijstViewModel(this,"Overnachting");
        }

        private void showBars()
        {
            CurrentData = new LijstViewModel(this,"Bar");
        }

        private void showRestaurants()
        {
            CurrentData = new LijstViewModel(this,"Restaurant");
        }

        private ViewModelBase _currentData;
        public ViewModelBase CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

        private void ShowOndernemingen()
        {
            CurrentData = new LijstViewModel(this);
        }

    }
}
