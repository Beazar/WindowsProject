using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    class RegistreerAlsGebruikerViewModel : ViewModelBase
    {
        private ViewModelBase _currentData;
        public ViewModelBase CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

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

        public RegistreerAlsGebruikerViewModel()
        {
            AddGebruikerCommand = new RelayCommand(param => maakGebruikerAan((PasswordBox)param));
        }

        private async void maakGebruikerAan(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            Wachtwoord = passwordBox.Password;
            var CreatedGebruiker = new Gebruiker(Gebruikersnaam,Wachtwoord);
            Debug.Write(CreatedGebruiker.Gebruikersnaam);
            Debug.Write(CreatedGebruiker.Wachtwoord);
            HttpClient client = new HttpClient();
            var json = await client.PostAsJsonAsync(new Uri("http://localhost:52974/api/gebruikers/"),
                CreatedGebruiker);
            Debug.WriteLine(json);
            Debug.Write("methode volledig doorlopen");

        }


    }
}
