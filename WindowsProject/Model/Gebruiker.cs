using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model
{
    public class Gebruiker : INotifyPropertyChanged
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

        private string _abonnementen;

        public string Abonnementen
        {
            get { return _abonnementen; }
            set { _abonnementen = value; RaisePropertyChanged(); }
        }

        private List<Onderneming> _listAbonnementen;

        public List<Onderneming> ListAbonnementen
        {
            get { return _listAbonnementen; }
            set { _listAbonnementen = value; RaisePropertyChanged(); }
        }



        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Gebruiker(string gebruikersnaam, string wachtwoord)
        {
            this._gebruikersnaam = gebruikersnaam;
            this._wachtwoord = wachtwoord;
            this._listAbonnementen = new List<Onderneming>();
            this.Abonnementen = "";
        }
    }
}
