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

        private int _postcode;
		public int Postcode
		{
			get { return _postcode; }
			set { _postcode = value; RaisePropertyChanged(); }
		}
        

		private string _categorie;
		public string Categorie
		{
			get { return _categorie; }
			set { _categorie = value; RaisePropertyChanged(); }
		}

        public Onderneming(string naam, string adres, string plaats, string beschrijving, int postcode, string categorie)
        {
            _naam = naam;
            _adres = adres;
            _plaats = plaats;
            _beschrijving = beschrijving;
            _postcode = postcode;
            _categorie = categorie;
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
