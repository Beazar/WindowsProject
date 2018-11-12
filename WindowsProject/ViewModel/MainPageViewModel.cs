using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.ViewModel
{
    class MainPageViewModel : ViewModelBase
    {
        public RelayCommand AllOndernemingenCommand { get; set; }
        public RelayCommand RestaurantsCommand { get; set; }
        public RelayCommand BarsCommand { get; set; }
        public RelayCommand OvernachtingCommand { get; set; }
        public RelayCommand AndereCommand { get; set; }
        public RelayCommand KledingCommand { get; set; }
        public RelayCommand KappersCommand { get; set; }

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
        }

        private void showKappers()
        {
            CurrentData = new LijstViewModel("Kappers");
        }

        private void showKleding()
        {
            CurrentData = new LijstViewModel("Kleding");
        }

        private void showAndere()
        {
            CurrentData = new LijstViewModel("Andere");
        }

        private void showOvernachting()
        {
            CurrentData = new LijstViewModel("Overnachting");
        }

        private void showBars()
        {
            CurrentData = new LijstViewModel("Bars");
        }

        private void showRestaurants()
        {
            CurrentData = new LijstViewModel("Restaurants");
        }

        private ViewModelBase _currentData;
        public ViewModelBase CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

        private void ShowOndernemingen()
        {
            CurrentData = new LijstViewModel();
            Debug.WriteLine("ShowOndernemingen called");
        }

    }
}
