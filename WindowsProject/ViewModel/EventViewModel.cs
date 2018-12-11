using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
   public class EventViewModel:ViewModelBase
    {
        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { _events = value; RaisePropertyChanged(); }
        }

        private MainPageViewModel Mp;
        public RelayCommand ToevoegenCommand { get; set; }


        public EventViewModel(MainPageViewModel mp)
        {
            this.Mp = mp;
            this.Events = new ObservableCollection<Event>(mp.LoggedInOnderneming.Events);
            ToevoegenCommand = new RelayCommand(_ => showToevoegen());

        }

        private void showToevoegen()
        {
            this.Mp.CurrentData = new EventToevoegenViewModel(this.Mp);
        }
    }
}
