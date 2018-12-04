using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsProjectService.Models
{
    public class Onderneming
    {
        public int OndernemingID { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
        public string Beschrijving { get; set; }
        public string Categorie { get; set; }
        public string TelefoonNummer { get; set; }
        public string Website { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Afbeeldingen { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Promotie> Promoties { get; set; }
    
    }
}