using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model
{
	class Onderneming : INotifyPropertyChanged
	{

		private string _naam;
		public string Naam
		{
			get { return _naam; }
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
			set { _naam = value; RaisePropertyChanged(); }
		}


		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
