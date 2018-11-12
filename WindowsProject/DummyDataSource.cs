using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject
{
    public class DummyDataSource
    {
        public static List<Onderneming> Ondernemingen { get; set; } = new List<Onderneming>()
        {
            new Onderneming(){Naam="Mozart", Adres = "Zwarte Zustersstraat 6", Postcode=9300, Plaats="Aalst", Categorie="Restaurants", Beschrijving="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eget erat tempor, vehicula nisi eget, hendrerit lorem. Sed eget ultricies nisl, ornare blandit quam. Nam condimentum ullamcorper sapien eu ornare." },
            new Onderneming(){Naam="Comme ça", Adres = "Sluierstraat 5", Postcode=9300, Plaats="Aalst", Categorie="Bars", Beschrijving="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eget erat tempor, vehicula nisi eget, hendrerit lorem. Sed eget ultricies nisl, ornare blandit quam. Nam condimentum ullamcorper sapien eu ornare." },
            new Onderneming(){Naam="Gaudi Bianca", Adres = "Molenstraat 22 a", Postcode=9300, Plaats="Aalst", Categorie="Kappers", Beschrijving="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eget erat tempor, vehicula nisi eget, hendrerit lorem. Sed eget ultricies nisl, ornare blandit quam. Nam condimentum ullamcorper sapien eu ornare." },
            new Onderneming(){Naam="Best Western Premier Keizershof Hotel", Adres = "Korte Nieuwstraat 15", Postcode=9300, Plaats="Aalst", Categorie="Overnachting", Beschrijving="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eget erat tempor, vehicula nisi eget, hendrerit lorem. Sed eget ultricies nisl, ornare blandit quam. Nam condimentum ullamcorper sapien eu ornare." },
            new Onderneming(){Naam="Charmant", Adres = "Brusselse Steenweg 222", Postcode=9300, Plaats="Aalst", Categorie="Kleding", Beschrijving="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eget erat tempor, vehicula nisi eget, hendrerit lorem. Sed eget ultricies nisl, ornare blandit quam. Nam condimentum ullamcorper sapien eu ornare." },
            new Onderneming(){Naam="Cube 10 Escape Games", Adres = "Molenstraat 50", Postcode=9300, Plaats="Aalst", Categorie="Andere", Beschrijving="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eget erat tempor, vehicula nisi eget, hendrerit lorem. Sed eget ultricies nisl, ornare blandit quam. Nam condimentum ullamcorper sapien eu ornare." }
        };
    }
}
