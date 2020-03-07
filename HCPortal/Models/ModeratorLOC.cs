using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCPortal.Models
{
    public class ModeratorLOC
    {
        public int sifra_moderatora { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnicko_ime { get; set; }
        public string sifra { get; set; }
        public string datum_rodjenja { get; set; }
    }
}