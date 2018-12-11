using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class EventToevoegenViewModel: ViewModelBase
    {
        private MainPageViewModel Mp;
        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged(); }
        }
        private DateTimeOffset _startDatum;

        public DateTimeOffset StartDatum
        {
            get { return _startDatum; }
            set { _startDatum = value; RaisePropertyChanged(); }
        }
        private TimeSpan _startUur;

        public TimeSpan StartUur
        {
            get { return _startUur; }
            set { _startUur = value; RaisePropertyChanged(); }
        }

        private DateTimeOffset _eindDatum;

        public DateTimeOffset EindDatum
        {
            get { return _eindDatum; }
            set { _eindDatum = value; RaisePropertyChanged(); }
        }
        private TimeSpan _eindUur;

        public TimeSpan EindUur
        {
            get { return _eindUur; }
            set { _eindUur = value; RaisePropertyChanged(); }
        }
        public RelayCommand AddEventCommand { get; set; }




        public EventToevoegenViewModel(MainPageViewModel mp)
        {
            this.Mp = mp;
            AddEventCommand = new RelayCommand(_ => maakEventAan());
        }

        private async void maakEventAan()
        {
         
            DateTime start = new DateTime(this.StartDatum.Year, this.StartDatum.Month, this.StartDatum.Day, this.StartUur.Hours,0,0);
            DateTime Eind = new DateTime(this.EindDatum.Year, this.EindDatum.Month, this.EindDatum.Day, this.EindUur.Hours, 0, 0);
            //start.AddYears(this.StartDatum.Year);
            //start.AddMonths(this.StartDatum.Month);
            //start.AddDays(this.StartDatum.Day);
            //start.AddHours(this.StartUur.Hours);
            //Eind.AddYears(this.EindDatum.Year);
            //Eind.AddMonths(this.EindDatum.Month);
            //Eind.AddDays(this.EindDatum.Day);
            //Eind.AddHours(this.EindUur.Hours);



            var CreatedEvent = new Event(this.Naam,start,Eind,this.Mp.LoggedInOnderneming.OndernemingID);
            HttpClient client = new HttpClient();
            var json = await client.PostAsJsonAsync(new Uri("http://localhost:52974/api/events"), CreatedEvent);
            var ond = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/" + Mp.LoggedInOnderneming.OndernemingID));
            Mp.LoggedInOnderneming = JsonConvert.DeserializeObject<Onderneming>(ond);
            Mp.CurrentData = new EventViewModel(this.Mp);
        }
    }
}
