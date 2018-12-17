using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DeleteCommand = new RelayCommand(_ => DeleteAbonnement());
        }

        public async void DeleteAbonnement()
        {
            this.Mp.LoggedInGebruiker.ListAbonnementen.RemoveAll( ond => ond == this.SelectedOnderneming);
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
            HttpClient client = new HttpClient();
            var json = await client.PutAsJsonAsync(new Uri("http://localhost:52974/api/gebruikers/" + this.Mp.LoggedInGebruiker.Gebruikerid),
                this.Mp.LoggedInGebruiker);
            this.ListAbonnementen = new ObservableCollection<Onderneming>(this.Mp.LoggedInGebruiker.ListAbonnementen);

            //     Mp.CurrentData = new AbonnementenViewModel(this.Mp);
        }


    }
}
