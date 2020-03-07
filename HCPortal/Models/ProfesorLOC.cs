using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCPortal.Models
{
    public class ProfesorLOC
    {
        public int sifra_profesora { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datum_rodjenja { get; set; }
        public string mesto_stanovanja { get; set; }
        public string jmbg { get; set; }
    }
}