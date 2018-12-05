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
    public class Event : INotifyPropertyChanged
    {
        private int _eventID;
        private string _naam;
        private DateTime _startDatum;
        private DateTime _eindDatum;
        private int _ondernemingID;
        private Onderneming _onderneming;

        public int EventID
        {
            get { return _eventID; }
            set { _eventID = value;RaisePropertyChanged(); }
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
            set { _onderneming = value;RaisePropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}