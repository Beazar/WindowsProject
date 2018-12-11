using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    class SignInViewModel : ViewModelBase
    {
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

        public RelayCommand LoginCommand { get; set; }
        public SignInViewModel()
        {
            LoginCommand = new RelayCommand(param => Login());
        }

        private void Login()
        {
            LoggedInGebruiker = new Gebruiker(Gebruikersnaam, Wachtwoord);
        }
    }
}
