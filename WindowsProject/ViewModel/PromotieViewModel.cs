using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class PromotieViewModel: ViewModelBase
    {
        private MainPageViewModel mp;
        private ObservableCollection<Promotie> _promoties;
        public ObservableCollection<Promotie> Promoties
        {
            get { return _promoties; }
            set { _promoties = value; }
        }

        public RelayCommand ToevoegenCommand { get; set; }

        public PromotieViewModel(MainPageViewModel mp)
        {
            this.mp = mp;
            this.Promoties = new ObservableCollection<Promotie>(mp.LoggedInGebruiker.Events);
            ToevoegenCommand = new RelayCommand(_ => showToevoegen());
        }

        private void showToevoegen()
        {
            this.mp.CurrentData = new PromotieToevoegenViewModel(this.mp);
        }
    }


}
