using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCPortal.Models
{
    public class OcenaUcenikaMetaLOC
    {
        public int sifra_ucenika { get; set; }
        public int sifra_predmeta { get; set; }
        public int? ocena { get; set; }
        public int? polugodiste { get; set; }
        public string opis_prikaz { get; set; }
        public int opis { get; set; }
        public string vreme_upisa { get; set; }
    }
}