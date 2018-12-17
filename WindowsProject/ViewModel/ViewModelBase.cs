using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private DataTemplate _template;

        public DataTemplate Template
        {
            get { return _template; }
            set { _template = value; RaisePropertyChanged("Template"); }
        }

        private bool _loggedIn;

        public bool LoggedIn
        {
            get { return _loggedIn; }
            set { _loggedIn = value; RaisePropertyChanged("LoggedIn"); }
        }

        private Gebruiker _loggedInGebruiker;

        public Gebruiker LoggedInGebruiker
        {
            get { return _loggedInGebruiker; }
            set { _loggedInGebruiker = value; GebruikersNaam = _loggedInGebruiker.Gebruikersnaam; RaisePropertyChanged("gebruiker"); }
        }
        private Onderneming _loggedInOnderneming;

        public Onderneming LoggedInOnderneming
        {
            get { return _loggedInOnderneming; }
            set { _loggedInOnderneming = value; GebruikersNaam = _loggedInOnderneming.Gebruikersnaam; RaisePropertyChanged("onderneming"); }
        }

        private string _gebruikersNaam;

        public string GebruikersNaam
        {
            get { return _gebruikersNaam; }
            set { _gebruikersNaam = value; RaisePropertyChanged("gebruikersNaam"); }
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelBase()
        {
            //this.LoggedInGebruiker = new Gebruiker("sander", "sander");
            //stelGebruikerIn();
            Template = GetTemplate();
            
        }

        private async void stelGebruikerIn()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/1"));
            var ond = JsonConvert.DeserializeObject<Onderneming>(json);
            this.LoggedInOnderneming = ond;
        }

        private DataTemplate GetTemplate()
        {
            string s = GetType().Name;
            return (DataTemplate)App.Current.Resources[s];
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}