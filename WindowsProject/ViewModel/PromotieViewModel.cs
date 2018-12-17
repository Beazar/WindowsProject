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
    public class PromotieViewModel: ViewModelBase
    {

        public RelayCommand DeleteCommand { get; set; }

        private Promotie _selectedPromotie;

        public Promotie SelectedPromotie
        {
            get { return _selectedPromotie; }
            set { _selectedPromotie = value; RaisePropertyChanged(); }
        }

        private MainPageViewModel Mp;
        private ObservableCollection<Promotie> _promoties;
        public ObservableCollection<Promotie> Promoties
        {
            get { return _promoties; }
            set { _promoties = value; RaisePropertyChanged(); }
        }

        

        public RelayCommand ToevoegenCommand { get; set; }

        public PromotieViewModel(MainPageViewModel mp)
        {
            this.Mp = mp;
            this.Promoties = new ObservableCollection<Promotie>(mp.LoggedInOnderneming.Promoties);
            ToevoegenCommand = new RelayCommand(_ => showToevoegen());
            DeleteCommand = new RelayCommand(_ => DeletePromotie());
        }


        private async void DeletePromotie()
        {
            Mp.LoggedInOnderneming.Promoties.Remove(this.SelectedPromotie);
            HttpClient client = new HttpClient();
            await client.DeleteAsync(new Uri("http://localhost:52974/api/promoties/" + this.SelectedPromotie.PromotieID));
            this.Promoties = new ObservableCollection<Promotie>(this.Mp.LoggedInOnderneming.Promoties);
        }

        private void showToevoegen()
        {
            this.Mp.CurrentData = new PromotieToevoegenViewModel(this.Mp);
        }
    }


}
