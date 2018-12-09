using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model
{
    class Gebruiker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _gebruikerid;

        public int Gebruikerid
        {
            get { return _gebruikerid; }
            set { _gebruikerid = value; RaisePropertyChanged(); }
        }

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

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Gebruiker(string gebruikersnaam, string wachtwoord)
        {
            this._gebruikersnaam = gebruikersnaam;
            this._wachtwoord = wachtwoord;
        }
    }
}
