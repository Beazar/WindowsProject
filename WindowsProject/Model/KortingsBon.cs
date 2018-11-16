using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace WindowsProject.Model
{
    public class KortingsBon : INotifyPropertyChanged
    {
        private int _kortingsBonID;
        private string _naam;
        private double _procent;
        private DateTime _vervalDatum;
        private int _ondernemingID;
        private Promotie _promotie;

        public int KortingsBonID
        {
            get { return _kortingsBonID; }
            set { _kortingsBonID = value;RaisePropertyChanged(); }
        }
        public string Naam
        {
            get { return _naam; }
            set { _naam = value;RaisePropertyChanged(); }
        }
        public double Procent
        {
            get { return _procent; }
            set { _procent = value;RaisePropertyChanged(); }
        }
        public DateTime VervalDatum
        {
            get { return _vervalDatum; }
            set { _vervalDatum = value;RaisePropertyChanged(); }
        }

        // [ForeignKey("Promotie")]
        public int OndernemingID
        {
            get { return _ondernemingID; }
            set { _ondernemingID = value;RaisePropertyChanged(); }
        }
        // [JsonIgnore]
        public virtual Promotie Promotie
        {
            get { return _promotie; }
            set { _promotie = value;RaisePropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}