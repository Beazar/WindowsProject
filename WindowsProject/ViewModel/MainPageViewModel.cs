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
        public RelayCommand ToonAlleOndernemingenCommand { get; set; }
        public RelayCommand LogUitCommand { get; set; }


        private Visibility _isVisibleUser;

        public Visibility IsVisibleUser
        {
            get { return _isVisibleUser; }
            set { _isVisibleUser = value; RaisePropertyChanged(); }
        }

        private Visibility _isVisibleOnderneming;

        public Visibility IsVisibleOnderneming
        {
            get { return _isVisibleOnderneming; }
            set { _isVisibleOnderneming = value; RaisePropertyChanged(); }
        }

        private Visibility _isVisibleNietIngelogd;

        public Visibility IsVisibleNietIngelogd
        {
            get { return _isVisibleNietIngelogd; }
            set { _isVisibleNietIngelogd = value; RaisePropertyChanged(); }
        }

        private Visibility _isVisibleIngelogd;

        public Visibility IsVisibleIngelogd
        {
            get { return _isVisibleIngelogd; }
            set { _isVisibleIngelogd = value; RaisePropertyChanged(); }
        }




        public MainPageViewModel()
        {
            ShowOndernemingen(); //toon de ondernemingen direct
            AllOndernemingenCommand = new RelayCommand(_ => ShowPromoties());
            BarsCommand = new RelayCommand(_ => showBars());
            RestaurantsCommand = new RelayCommand(_ => showRestaurants());
            OvernachtingCommand = new RelayCommand(_ => showOvernachting());
            AndereCommand = new RelayCommand(_ => showAndere());
            KledingCommand = new RelayCommand(_ => showKleding());
            KappersCommand = new RelayCommand(_ => showKappers());
            SignInCommand = new RelayCommand(_ => showLogin());
            RegistreerGebruikerCommand = new RelayCommand(_ => showRegistreerGebruiker());
            RegistreerOndernemerCommand = new RelayCommand(_ => showRegistreerOndernemer());
            VoegEventToeCommand = new RelayCommand( _ => showEvent());
            VoegPromotieToeCommand = new RelayCommand( _ => showPromotie());
            NaarAbonnementenCommand = new RelayCommand( _ => showAbonnementen());
            ToonAlleOndernemingenCommand = new RelayCommand(_ => ShowOndernemingen());
            LogUitCommand = new RelayCommand(_ => LogUit());


            if(this.LoggedInGebruiker == null && this.LoggedInOnderneming == null)
            {
                this.IsVisibleNietIngelogd = Visibility.Visible;
                this.IsVisibleIngelogd = Visibility.Collapsed;
                this.IsVisibleOnderneming = Visibility.Collapsed;
                this.IsVisibleUser = Visibility.Collapsed;
            } else if(this.LoggedInGebruiker == null && this.LoggedInOnderneming != null)
            {
                this.IsVisibleNietIngelogd = Visibility.Collapsed;
                this.IsVisibleIngelogd = Visibility.Visible;
                this.IsVisibleOnderneming = Visibility.Visible;
                this.IsVisibleUser = Visibility.Collapsed;
            } else if(this.LoggedInGebruiker != null && this.LoggedInOnderneming == null)
            {
                this.IsVisibleNietIngelogd = Visibility.Collapsed;
                this.IsVisibleIngelogd = Visibility.Visible;
                this.IsVisibleOnderneming = Visibility.Collapsed;
                this.IsVisibleUser = Visibility.Visible;
            }

        }

        private void LogUit()
        {
            this.LoggedInGebruiker = null;
            this.LoggedInOnderneming = null;
            this.LoggedIn = false;
            this.IsVisibleNietIngelogd = Visibility.Visible;
            this.IsVisibleIngelogd = Visibility.Collapsed;
            this.IsVisibleOnderneming = Visibility.Collapsed;
            this.IsVisibleUser = Visibility.Collapsed;
            CurrentData = new LijstViewModel(this);

        }


        private void showAbonnementen()
        {
            CurrentData = new AbonnementenViewModel(this);
        }

        private void showPromotie()
        {
            CurrentData = new PromotieViewModel(this);
        }

        private void showEvent()
        {
            CurrentData = new EventViewModel(this);
        }

        private void showRegistreerOndernemer()
        {
            CurrentData = new RegistreerAlsOndernemerViewModel(this);
        }

        private void showRegistreerGebruiker()
        {
            CurrentData = new RegistreerAlsGebruikerViewModel(this);
        }

        private void showLogin()
        {
            CurrentData = new SignInViewModel(this);
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

        private void ShowOndernemingen()
        {
            CurrentData = new LijstViewModel(this);
        }

        private ViewModelBase _currentData;
        public ViewModelBase CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

        private void ShowPromoties()
        {
            CurrentData = new LijstViewModel(this, "Promoties");
        }

    }
}
