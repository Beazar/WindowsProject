using System.Collections.ObjectModel;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class LijstViewModel : ViewModelBase
    {
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }

        public RelayCommand SaveOndernemingCommand { get; set; }

        public LijstViewModel()
        {
            this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen);
            SaveOndernemingCommand = new RelayCommand((p) => SaveOnderneming(p));
        }

        public LijstViewModel(string filter)
        {
            this.Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen.FindAll(o => o.Categorie == filter));
        }

        private void SaveOnderneming(object p)
        {
            //this.ondernemingen.Add(new Onderneming { Naam = p.ToString(), Categorie =})
        }
    }
}