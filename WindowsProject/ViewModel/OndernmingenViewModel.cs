using System.Collections.ObjectModel;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class OndernemingenViewModel : ViewModelBase
    {
        public ObservableCollection<Onderneming> ondernemingen { get; set; }

        public RelayCommand SaveOndernemingCommand { get; set; }

        public OndernemingenViewModel()
        {
            this.ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.ondernemingen);
            SaveOndernemingCommand = new RelayCommand((p) => SaveOnderneming(p));
        }

        private void SaveOnderneming(object p)
        {
            //this.ondernemingen.Add(new Onderneming { Naam = p.ToString(), Categorie =})
        }
    }
}