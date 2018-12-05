using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    class RegistreerAlsOndernemerViewModel : ViewModelBase
    {

        //public RelayCommand RegistreerOndernemer;
        private ViewModelBase _currentData;
        public ViewModelBase CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

        public RelayCommand AddOndernemingCommand { get; set; }

        private String _plaats;

        public String Plaats
        {
            get { return _plaats; }
            set { _plaats = value; RaisePropertyChanged(); }
        }

        private String _postcode;

        public String Postcode
        {
            get { return _postcode; }
            set { _postcode = value; RaisePropertyChanged(); }
        }

        private string _gebruikersnaam = "user";

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

        private string _telefoon;

        public string Telefoon
        {
            get { return _telefoon; }
            set { _telefoon = value; RaisePropertyChanged(); }
        }

        private string _afbeelding;

        public string Afbeelding
        {
            get { return _afbeelding; }
            set { _afbeelding = value; RaisePropertyChanged(); }
        }

        private string _website;

        public string Website
        {
            get { return _website; }
            set { _website = value; RaisePropertyChanged(); }
        }

        private string _beschrijving;

        public string Beschrijving
        {
            get { return _beschrijving; }
            set { _beschrijving = value; RaisePropertyChanged(); }
        }

        private string _categorie;

        public string Categorie
        {
            get { return _categorie; }
            set { _categorie = value; RaisePropertyChanged(); }
        }


        private String _adres;

        public String Adres
        {
            get { return _adres; }
            set { _adres = value; RaisePropertyChanged(); }
        }



        private String _ondernemingnummer;

        public String Ondernemingsnummer
        {
            get { return _ondernemingnummer; }
            set { _ondernemingnummer = value; RaisePropertyChanged(); Nummer_TextChanging(); }
        }

        private String _naam;

        public String Naam
        {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged(); }
        }

        public RegistreerAlsOndernemerViewModel()
        {
            AddOndernemingCommand = new RelayCommand(param => maakOndernemingAan((PasswordBox)param));
        }

        private void maakOndernemingAan(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            Wachtwoord = passwordBox.Password;
            var CreatedOnderneming = new Onderneming(Naam, Adres, Plaats, Beschrijving, Postcode, Categorie, Telefoon, Website, Afbeelding, Gebruikersnaam, Wachtwoord);

        }

        string previousInput = "";
        private async void Nummer_TextChanging()
        {
            Debug.Write("previousInput aangeroepen");
            Regex r = new Regex("^[0-9]*$"); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(Ondernemingsnummer);
            if (m.Success)
            {
                previousInput = Ondernemingsnummer;
                await newOndernemingAsync();
            }
            else
            {
                Ondernemingsnummer = previousInput;
            }
        }

        private async Task newOndernemingAsync()
        {
            var url = @"https://www2.unizo.be/graydon_zoek.jsp?dry=1&btw=" + Ondernemingsnummer;
            HtmlWeb web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);
            //var doc = web.Load(@"https://www2.unizo.be/graydon_zoek.jsp?dry=1&btw=0895478066");
            Naam = doc.DocumentNode.SelectSingleNode("//*[@id='full']/h1").InnerHtml.Substring(7);
            var text = doc.DocumentNode.SelectSingleNode("//*[@id='full']/article").InnerHtml;
            string toBeSearched = "Adres: ";
            string toBeSearched2 = "<br>Juri";
            int start = text.IndexOf(toBeSearched) + toBeSearched.Length;
            int end = text.IndexOf(toBeSearched2);
            string code = text.Substring(start, end - start);
            var stringarr = code.Split("-");
            Adres = stringarr.First();
            stringarr.Last().Trim();
            Postcode = stringarr.Last().Substring(1, 5);
            var stringarr2 = stringarr.Last().Split(" ");
            var plaats = stringarr2.Last();
            var plaatsarr = plaats.Split('\\');
            Plaats = plaatsarr.First();
        }

    }
}
