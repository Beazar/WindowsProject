using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        private String _ondernemingnummer = "test";

        public String Ondernemingsnummer
        {
            get { return _ondernemingnummer; }
            set { _ondernemingnummer = value; Debug.Write("setter aangeroepen"); RaisePropertyChanged(); Nummer_TextChanging(); }
        }

        private String _naam;

        public String Naam
        {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged(); }
        }

        public RegistreerAlsOndernemerViewModel()
        {

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
            Debug.Write(Naam);
            var text = doc.DocumentNode.SelectSingleNode("//*[@id='full']/article").InnerHtml;
            string toBeSearched = "Adres: ";
            string toBeSearched2 = "<br>Juri";
            int start = text.IndexOf(toBeSearched) + toBeSearched.Length;
            int end = text.IndexOf(toBeSearched2);
            string code = text.Substring(start, end - start);
            //= code;
        }

    }
}
