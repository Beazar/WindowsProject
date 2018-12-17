using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    class RegistreerAlsGebruikerViewModel : ViewModelBase
    {
        private MainPageViewModel Mp;

        public RelayCommand AddGebruikerCommand { get; set; }

        private string _gebruikersnaam;

        public string Gebruikersnaam
        {
            get { return _gebruikersnaam; }
            set { _gebruikersnaam = value; RaisePropertyChanged(); }
        }

        private string _wachtwoord;

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; RaisePropertyChanged(); }
        }

        public RegistreerAlsGebruikerViewModel(MainPageViewModel mp)
        {
            AddGebruikerCommand = new RelayCommand(param => maakGebruikerAan((PasswordBox)param));
            this.Mp = mp;
        }

        private async void maakGebruikerAan(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            Wachtwoord = passwordBox.Password;
            var CreatedGebruiker = new Gebruiker(Gebruikersnaam, Wachtwoord);
            HttpClient client = new HttpClient();
            var json = await client.PostAsJsonAsync(new Uri("http://localhost:52974/api/gebruikers/"),
                CreatedGebruiker);

            //    var idArray = this.Mp.LoggedInGebruiker.Abonnementen.Split(';');
            this.Mp.LoggedInGebruiker = CreatedGebruiker;
            this.Mp.LoggedIn = true;
            this.Mp.IsVisibleIngelogd = Visibility.Visible;
            this.Mp.IsVisibleNietIngelogd = Visibility.Collapsed;
            this.Mp.IsVisibleUser = Visibility.Visible;
            this.Mp.IsVisibleOnderneming = Visibility.Collapsed;
            this.Mp.CurrentData = new LijstViewModel(this.Mp);

        }


    }
}
