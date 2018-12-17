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

        private MainPageViewModel _mpvm;

        public MainPageViewModel MPVM
        {
            get { return _mpvm; }
            set { _mpvm = value; RaisePropertyChanged(); }
        }

        private ViewModelBase _currentData;

        public ViewModelBase Currentdata
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

        public SignInViewModel(MainPageViewModel mpvm)
        {
            Debug.Write("voor toewijzen MPVM");
            MPVM = mpvm;
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
            if (jsonG != null && MPVM != null)
            {
                Gebruiker userG = JsonConvert.DeserializeObject<Gebruiker>(jsonG);
                if (userG != null)
                {
                    MPVM.LoggedInGebruiker = userG;
                    MPVM.LoggedIn = true;
                    this.MPVM.CurrentData = new LijstViewModel(this.MPVM);
                }
            }
            else if (jsonO != null && MPVM != null)
            {
                Onderneming userO = JsonConvert.DeserializeObject<Onderneming>(jsonO);
                if (userO != null)
                {
                    MPVM.LoggedInOnderneming = userO;
                    MPVM.LoggedIn = true;
                    this.MPVM.CurrentData = new LijstViewModel(this.MPVM);
                }
            }
        }
    }
}
