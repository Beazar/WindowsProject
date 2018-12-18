using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class AbonnementenViewModel : ViewModelBase
    {
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand BekijkCommand { get; set; }

        private Onderneming _selectedOnderneming;

        public Onderneming SelectedOnderneming
        {
            get { return _selectedOnderneming; }
            set { _selectedOnderneming = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Onderneming> _listAbonnementen;

        public ObservableCollection<Onderneming> ListAbonnementen
        {
            get { return _listAbonnementen; }
            set { _listAbonnementen = value; RaisePropertyChanged(); }
        }

        private MainPageViewModel Mp { get; set; }

        public AbonnementenViewModel(MainPageViewModel mp)
        {
            this.Mp = mp;
            this.ListAbonnementen = new ObservableCollection<Onderneming>(this.Mp.LoggedInGebruiker.ListAbonnementen);
            DeleteCommand = new RelayCommand(async Id => await DeleteAbonnement(Id));
            BekijkCommand = new RelayCommand(async Id => await BekijkOnderneming(Id));
        }

        public async Task BekijkOnderneming(object id)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/" + id.ToString()));
            SelectedOnderneming = JsonConvert.DeserializeObject<Onderneming>(json);
            this.Mp.CurrentData = new DetailViewModel(SelectedOnderneming,this.Mp);
        }

        public async Task DeleteAbonnement(object id)
        {
            HttpClient client = new HttpClient();
            var jsonO = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/" + id.ToString()));
            SelectedOnderneming = JsonConvert.DeserializeObject<Onderneming>(jsonO);
            //this.Mp.LoggedInGebruiker.ListAbonnementen.RemoveAll( ond => ond == this.SelectedOnderneming);
            //this.Mp.LoggedInGebruiker.ListAbonnementen.Where(o => o.OndernemingID.ToString() == id.ToString());
            this.Mp.LoggedInGebruiker.ListAbonnementen = this.Mp.LoggedInGebruiker.ListAbonnementen.Where(o => o.OndernemingID.ToString() != id.ToString()).ToList();
            string nieuweLijst = "";
            var AboArray = this.Mp.LoggedInGebruiker.Abonnementen.Split(";");
            for(int i = 0; i < AboArray.Length - 1; i++)
            {
                if(AboArray[i] != this.SelectedOnderneming.OndernemingID.ToString())
                {
                    nieuweLijst += AboArray[i] + ";";

                }
            }
            this.Mp.LoggedInGebruiker.Abonnementen = nieuweLijst;
            client = new HttpClient();
            var json = await client.PutAsJsonAsync(new Uri("http://localhost:52974/api/gebruikers/" + this.Mp.LoggedInGebruiker.Gebruikerid),
                this.Mp.LoggedInGebruiker);
            this.ListAbonnementen = new ObservableCollection<Onderneming>(this.Mp.LoggedInGebruiker.ListAbonnementen);

            //     Mp.CurrentData = new AbonnementenViewModel(this.Mp);
        }


    }
}
