using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model
{
	public class Onderneming : INotifyPropertyChanged
	{
        private int _ondernemingID;
        public int OndernemingID
        {
            get { return _ondernemingID; }
            set { _ondernemingID = value; RaisePropertyChanged(); }
        }

        private string _gebruikersnaam;

        public string Gebruikersnaam
        {
            get { return _gebruikersnaam; }
            set { _gebruikersnaam = value; }
        }

        private string _wachtwoord;

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }


        public string TelefoonNummer
        {
            get { return _telefoonNummer; }
            set { _telefoonNummer = value; RaisePropertyChanged(); }
        }
        public string Website
        {
            get { return _website; }
            set { _website = value; RaisePropertyChanged(); }
        }
        public string Afbeelding
        {
            get { return _afbeelding; }
            set { _afbeelding = value;RaisePropertyChanged(); }
        }

        public virtual ICollection<Event> Events
        {
            get { return _events; }
            set { _events = value; RaisePropertyChanged(); }
        }
        public virtual ICollection<Promotie> Promoties
        {
            get { return _promoties; }
            set { _promoties = value; RaisePropertyChanged(); }
        }
        private string _naam;
		public string Naam
		{
			get { RaisePropertyChanged(); return _naam;  }
			set { _naam = value; RaisePropertyChanged(); }
		}

		private string _adres;
		public string Adres
		{
			get { return _adres; }
			set { _adres = value; RaisePropertyChanged(); }
		}

		private string _plaats;
		public string Plaats
		{
			get { return _plaats; }
			set { _plaats = value; RaisePropertyChanged(); }
		}


        private string _beschrijving;
        public string Beschrijving
        {
            get { return _beschrijving; }
            set { _beschrijving = value; RaisePropertyChanged(); }
        }

        private string _postcode;
		public string Postcode
		{
			get { return _postcode; }
			set { _postcode = value; RaisePropertyChanged(); }
		}
        

		private string _categorie;
        private string _telefoonNummer;
        private string _website;
        private string _afbeelding;
        private ICollection<Event> _events;
        private ICollection<Promotie> _promoties;

        public string Categorie
		{
			get { return _categorie; }
			set { _categorie = value; RaisePropertyChanged(); }
		}

        public Onderneming(string naam, string adres, string plaats, string beschrijving, string postcode,
            string categorie, string telefoonNummer, string website, string afbeelding)
        {
            _naam = naam;
            _adres = adres;
            _plaats = plaats;
            _beschrijving = beschrijving;
            _postcode = postcode;
            _categorie = categorie;
            _telefoonNummer = telefoonNummer;
            _website = website;
            _afbeelding = afbeelding;
        }

        public Onderneming(string naam, string adres, string plaats, string beschrijving, string postcode,
    string categorie, string telefoonNummer, string website, string afbeelding, string gebruikersnaam, string wachtwoord)
        {
            _naam = naam;
            _adres = adres;
            _plaats = plaats;
            _beschrijving = beschrijving;
            _postcode = postcode;
            _categorie = categorie;
            _telefoonNummer = telefoonNummer;
            _website = website;
            _afbeelding = afbeelding;
            _wachtwoord = wachtwoord;
            _gebruikersnaam = gebruikersnaam;
        }

        public Onderneming()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
