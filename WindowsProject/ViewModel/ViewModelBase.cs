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
            set { _loggedInGebruiker = value; RaisePropertyChanged("gebruiker"); }
        }
        private Onderneming _loggedInOnderneming;

        public Onderneming LoggedInOnderneming
        {
            get { return _loggedInOnderneming; }
            set { _loggedInOnderneming = value; RaisePropertyChanged("gebruiker"); }
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelBase()
        {
            //this.LoggedInGebruiker = new Gebruiker("sander", "sander");
            stelGebruikerIn();
            Template = GetTemplate();
            
        }

        private async void stelGebruikerIn()
        {
            
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/4"));
          //  var json4 = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings"));
            var ond = JsonConvert.DeserializeObject<Onderneming>(json); //.Substring(1,json.Length-2)
            this.LoggedInOnderneming = ond;
            
            var jsonG = await client.GetStringAsync(new Uri("http://localhost:52974/api/gebruikers/1"));
            var gebr = JsonConvert.DeserializeObject<Gebruiker>(jsonG); //.Substring(1, jsonG.Length - 2)
            this.LoggedInGebruiker = gebr;
          //  this.LoggedInGebruiker.
            if(this.LoggedInGebruiker.Abonnementen != "" && this.LoggedInGebruiker.Abonnementen != null)
            {
               var idArray = this.LoggedInGebruiker.Abonnementen.Split(';');
                for(int i = 0; i<idArray.Length-1; i++)
                {
                    var json2 = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/"+idArray[i]));
                    this.LoggedInGebruiker.ListAbonnementen.Add(JsonConvert.DeserializeObject<Onderneming>(json2)); //.Substring(1, json2.Length - 2)
                }
            }
        }

        private DataTemplate GetTemplate()
        {
            string s = GetType().Name;
            return (DataTemplate)App.Current.Resources[s];
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}