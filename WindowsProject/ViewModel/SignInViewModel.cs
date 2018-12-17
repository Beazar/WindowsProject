using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

        private MainPageViewModel Mp { get; set; }

        public SignInViewModel(MainPageViewModel mpvm)
        {
            Debug.Write("voor toewijzen MPVM");
            Mp = mpvm;
            Debug.Write("voor command");
            LoginCommand = new RelayCommand(param => Login());
            Debug.Write("na command");
        }

        public RelayCommand LoginCommand { get; set; }

        private async void Login()
        {
            //LoggedInGebruiker = new Gebruiker(Gebruikersnaam, Wachtwoord);
            Debug.WriteLine("Test");
            HttpClient client = new HttpClient();
            string jsonG = null;
            try
            {
                jsonG = await client.GetStringAsync(new Uri("http://localhost:52974/api/gebruikers/" + Gebruikersnaam + "_" + Wachtwoord));
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine("Geen gebruiker gevonden");
            }
            string jsonO = null;
            try
            {
                jsonO = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/" + Gebruikersnaam + "_" + Wachtwoord));
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine("Geen onderneming gevonden");
            }
            Debug.WriteLine(jsonG);
            Debug.WriteLine(jsonO);
            if (jsonG != null)
            {
                Gebruiker userG = JsonConvert.DeserializeObject<Gebruiker>(jsonG);
                if (userG != null)
                {
                    this.Mp.LoggedInGebruiker = userG;
                    if (this.Mp.LoggedInGebruiker.Abonnementen != "" && this.Mp.LoggedInGebruiker.Abonnementen != null)
                    {
                        var idArray = this.Mp.LoggedInGebruiker.Abonnementen.Split(';');
                        for (int i = 0; i < idArray.Length - 1; i++)
                        {
                            var json2 = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/" + idArray[i]));
                            this.Mp.LoggedInGebruiker.ListAbonnementen.Add(JsonConvert.DeserializeObject<Onderneming>(json2)); //.Substring(1, json2.Length - 2)
                        }
                    }
                    
                    this.Mp.LoggedIn = true;
                    this.Mp.CurrentData = new LijstViewModel(this.Mp);

                }
            }
            else if (jsonO != null)
            {
                Onderneming userO = JsonConvert.DeserializeObject<Onderneming>(jsonO);
                if (userO != null)
                {
                    Mp.LoggedInOnderneming = userO;
                    Mp.LoggedIn = true;
                    this.Mp.CurrentData = new LijstViewModel(this.Mp);
                }
            }
        }
    }
}
