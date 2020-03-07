using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCPortal.Models
{
    public class UcenikLOC
    {
        public int sifra_ucenika { get; set; }
        public OdeljenjeLOC odeljenje { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnicko_ime { get; set; }
        public string sifra { get; set; }
        public string datum_rodjenja { get; set; }
        public string mesto_stanovanja { get; set; }
        public string jmbg { get; set; }
        public string ime_staratelja { get; set; }
        public string prezime_staratelja { get; set; }
        public string kontakt_telefon { get; set; }
    }
}