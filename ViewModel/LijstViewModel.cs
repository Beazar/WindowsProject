using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class LijstViewModel : ViewModelBase
    {

        private ObservableCollection<Onderneming> _ondernemingen;
        private MainPageViewModel Mp;

        private Onderneming _selectedOnderneming { get; set; }
        public Onderneming SelectedOnderneming {
            get { return _selectedOnderneming;  }
            set
            {
                if (_selectedOnderneming != value)
                {
                    _selectedOnderneming = value;
                    RaisePropertyChanged();
                    HandleSelectedItem();
                }
            }
            }

        public RelayCommand NavigateToDetail { get; set; }

        private void HandleSelectedItem()
        {
            Debug.Write(this.Template);
            // this.Template = new DetailViewModel(SelectedOnderneming);
            Mp.CurrentData = new DetailViewModel(SelectedOnderneming);
            
        }

        public ObservableCollection<Onderneming> Ondernemingen
        {
            get { return _ondernemingen; }
            set { _ondernemingen = value; RaisePropertyChanged(); }
        }


        public RelayCommand SaveOndernemingCommand { get; set; }
        public RelayCommand ZoekCommand { get; set; }

        private string _zoek;

        public string Zoek
        {
            get { return _zoek; }
            set { _zoek = value;  ZoekOnderneming(_zoek); RaisePropertyChanged(); }
        }


        public LijstViewModel(MainPageViewModel mp)
        {
            // DummyDataSource.loadData();
            //this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen);
            loadData();
            SaveOndernemingCommand = new RelayCommand((p) => SaveOnderneming(p));
            ZoekCommand = new RelayCommand((p) => ZoekOnderneming(Zoek));
            this.Mp = mp;
        }
        public LijstViewModel(MainPageViewModel mp, string filter)
        {
            loadDataCategorie(filter);
            SaveOndernemingCommand = new RelayCommand((p) => SaveOnderneming(p));
            ZoekCommand = new RelayCommand((p) => ZoekOnderneming(Zoek));
            //this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen.Where(o => o.Categorie == filter));
        }
        
        private async void loadData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
            this.Ondernemingen = lst;
        }
        private async void loadDataCategorie(string filter)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/"));
            var lst = JsonConvert.DeserializeObject<List<Onderneming>>(json);
            
            lst = lst.Where(o => o.Categorie == filter).ToList();
            this.Ondernemingen = new ObservableCollection<Onderneming>(lst);
            //foreach (Onderneming o in lst) {
            //    this.Ondernemingen.Add(o);
            //        }
        }
        private async void loadDataZoek(string zoek)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/"));
            var lst = JsonConvert.DeserializeObject<List<Onderneming>>(json);

            lst = lst.Where(o => o.Naam.IndexOf(zoek, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            this.Ondernemingen = new ObservableCollection<Onderneming>(lst);
            //foreach (Onderneming o in lst)
            //{
            //    this.Ondernemingen.Add(o);
            //}
        }
        private void ZoekOnderneming(string zoek)
        {
            Debug.Write("Zoek onderneming opgeroepen\n");
            Debug.Write(zoek);
            //this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen.Where(o => o.Naam.IndexOf(zoek, StringComparison.OrdinalIgnoreCase) >= 0));
            //this.Ondernemingen = (ObservableCollection<Onderneming>)Ondernemingen.Where(o => o.Naam.IndexOf(zoek, StringComparison.OrdinalIgnoreCase) >= 0);
            loadDataZoek(zoek);
        }
        
        

        private void SaveOnderneming(object p)
        {
            //this.ondernemingen.Add(new Onderneming { Naam = p.ToString(), Categorie =})
        }
    }
}