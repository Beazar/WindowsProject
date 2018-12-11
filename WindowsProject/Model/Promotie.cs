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
    public class Promotie : INotifyPropertyChanged
    {
        private int _promotieID;
        private string _naam;
        private DateTime _startDatum;
        private DateTime _eindDatum;
        private int _ondernemingID;
        private Onderneming _onderneming;
        private ICollection<KortingsBon> _kortingsBonnen;

        public int PromotieID
        {
            get { return _promotieID; }
            set { _promotieID = value;RaisePropertyChanged(); }
        }
        public string Naam
        {
            get { return _naam; }
            set { _naam = value;RaisePropertyChanged(); }
        }
        public DateTime StartDatum
        {
            get { return _startDatum; }
            set { _startDatum = value;RaisePropertyChanged(); }
        }
        public DateTime EindDatum
        {
            get { return _eindDatum; }
            set { _eindDatum = value;RaisePropertyChanged(); }
        }
        //[ForeignKey("Onderneming")]
        public int OndernemingID
        {
            get { return _ondernemingID; }
            set { _ondernemingID = value;RaisePropertyChanged(); }
        }
        //[JsonIgnore]
        public virtual Onderneming Onderneming
        {
            get { return _onderneming; }
            set { _onderneming = value; RaisePropertyChanged(); }
        }
        public virtual ICollection<KortingsBon> KortingsBonnen
        {
            get { return _kortingsBonnen; }
            set { _kortingsBonnen = value;RaisePropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Promotie(string naam, DateTime startDatum, DateTime eindDatum, int ondernemingID)
        {
            _naam = naam;
            _startDatum = startDatum;
            _eindDatum = eindDatum;
            _ondernemingID = ondernemingID;
        }
    }
}