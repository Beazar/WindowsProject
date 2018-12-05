using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WindowsProjectService.Models
{
    public class KortingsBon
    {
        public int KortingsBonID { get; set; }
        public string Naam { get; set; }
        public double Procent { get; set; }
        public DateTime VervalDatum { get; set; }

        [ForeignKey("Promotie")]
        public int OndernemingID { get; set; }
        [JsonIgnore]
        public virtual Promotie Promotie { get; set; }
    }
}