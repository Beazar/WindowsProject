using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class LijstViewModel : ViewModelBase
    {

        private ObservableCollection<Onderneming> _ondernemingen;

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


        public LijstViewModel()
        {
            this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen);
            SaveOndernemingCommand = new RelayCommand((p) => SaveOnderneming(p));
            ZoekCommand = new RelayCommand((p) => ZoekOnderneming(Zoek));
        }

        private void ZoekOnderneming(string zoek)
        {
            Debug.Write("Zoek onderneming opgeroepen\n");
            Debug.Write(zoek);
            this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen.Where(o => o.Naam.IndexOf(zoek, StringComparison.OrdinalIgnoreCase) >= 0));
            
        }

        public LijstViewModel(string filter)
        {
            this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen.Where(o => o.Categorie == filter));
        }

        private void SaveOnderneming(object p)
        {
            //this.ondernemingen.Add(new Onderneming { Naam = p.ToString(), Categorie =})
        }
    }
}