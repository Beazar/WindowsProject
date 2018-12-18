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
            DeleteCommand = new RelayCommand(async id => await DeletePromotie(id));
        }


        private async Task DeletePromotie(object id)
        {
            this.Mp.LoggedInOnderneming.Promoties = this.Mp.LoggedInOnderneming.Promoties.Where(e => e.PromotieID.ToString() != id.ToString()).ToList();

           // Mp.LoggedInOnderneming.Promoties.Remove(this.SelectedPromotie);
            HttpClient client = new HttpClient();
            await client.DeleteAsync(new Uri("http://localhost:52974/api/promoties/" + id.ToString()));
            this.Promoties = new ObservableCollection<Promotie>(this.Mp.LoggedInOnderneming.Promoties);
        }

        private void showToevoegen()
        {
            this.Mp.CurrentData = new PromotieToevoegenViewModel(this.Mp);
        }
    }


}
