using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WindowsProjectService.Models
{
    public class Promotie
    {
        public int PromotieID { get; set; }
        public string Naam { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        [ForeignKey("Onderneming")]
        public int OndernemingID { get; set; }
        [JsonIgnore]
        public virtual Onderneming Onderneming { get; set; }
        public virtual ICollection<KortingsBon> KortingsBonnen { get; set; }
    }
}