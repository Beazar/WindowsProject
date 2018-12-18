using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
   public class EventViewModel:ViewModelBase
    {
        public RelayCommand DeleteCommand { get; set; }

        private Event _selectedEvent;

        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; RaisePropertyChanged(); }
        }


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
            DeleteCommand = new RelayCommand(async id => await DeleteEvent(id));

        }

        private async Task DeleteEvent(object id)
        {
            this.Mp.LoggedInOnderneming.Events = this.Mp.LoggedInOnderneming.Events.Where(e => e.EventID.ToString() != id.ToString()).ToList();
            //this.Mp.LoggedInOnderneming.Events.Remove(this.SelectedEvent);
            HttpClient client = new HttpClient();
            await client.DeleteAsync(new Uri("http://localhost:52974/api/events/" + id.ToString()));
            this.Events = new ObservableCollection<Event>(this.Mp.LoggedInOnderneming.Events);
        }

        private void showToevoegen()
        {
            this.Mp.CurrentData = new EventToevoegenViewModel(this.Mp);
        }
    }
}
