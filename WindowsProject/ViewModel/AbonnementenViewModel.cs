using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class AbonnementenViewModel : ViewModelBase
    {
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
        }


    }
}
