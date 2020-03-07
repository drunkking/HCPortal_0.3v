using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCPortal.Models
{
    public class OdeljenjeLOC
    {
        public int sifra_odeljenja { get; set; }
        public RazredLOC razred { get; set; }
        public string naziv { get; set; }
    }
}