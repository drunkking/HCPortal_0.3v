using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCPortal.Models
{
    public class PredmetLOC
    {
        public int sifra_predmeta { get; set; }
        public string naziv { get; set; }
        public List<RazredLOC> razredi { get; set; }

    }
}