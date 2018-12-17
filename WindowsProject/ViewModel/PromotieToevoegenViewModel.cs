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
    class PromotieToevoegenViewModel: ViewModelBase
    {
        private MainPageViewModel mp;
        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged(); }
        }
        
        private DateTimeOffset _startDatum = new DateTimeOffset(DateTime.Now);

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

        private DateTimeOffset _eindDatum = new DateTimeOffset(DateTime.Now);

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

        private string _kortingsbon;

        public string Kortingsbon
        {
            get { return _kortingsbon; }
            set { _kortingsbon = value; }
        }


        public RelayCommand addPromotieCommand { get; set; }



        public PromotieToevoegenViewModel(MainPageViewModel mp)
        {
            this.mp = mp;
            addPromotieCommand = new RelayCommand(param => voegPromotieToe());
        }

        private async void voegPromotieToe()
        {
            DateTime Start = new DateTime(this.StartDatum.Year, this.StartDatum.Month, this.StartDatum.Day, this.StartUur.Hours, 0, 0);
            DateTime Eind = new DateTime(this.EindDatum.Year, this.EindDatum.Month, this.EindDatum.Day, this.EindUur.Hours, 0, 0);
            //start.AddYears(this.StartDatum.Year);
            //start.AddMonths(this.StartDatum.Month);
            //start.AddDays(this.StartDatum.Day);
            //start.AddHours(this.StartUur.Hours);
            //Eind.AddYears(this.EindDatum.Year);
            //Eind.AddMonths(this.EindDatum.Month);
            //Eind.AddDays(this.EindDatum.Day);
            //Eind.AddHours(this.EindUur.Hours);



            var CreatedEvent = new Promotie(this.Naam, Start, Eind, this.Kortingsbon, this.mp.LoggedInOnderneming.OndernemingID);
            HttpClient client = new HttpClient();
            var json = await client.PostAsJsonAsync(new Uri("http://localhost:52974/api/promoties"), CreatedEvent); 
            var ond = await client.GetStringAsync(new Uri("http://localhost:52974/api/ondernemings/" + mp.LoggedInOnderneming.OndernemingID));
            mp.LoggedInOnderneming = JsonConvert.DeserializeObject<Onderneming>(ond.Substring(1,ond.Length-2));
            mp.CurrentData = new PromotieViewModel(this.mp);
        }


    }
}
