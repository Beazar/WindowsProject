using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsProjectService.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public virtual ICollection<Onderneming> Abonnementen {get; set;}
    }
}