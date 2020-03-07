using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IOdeljenje
    {
        OdeljenjeLOC traziOdeljenje(int? sifra_odeljenja);
        List<OdeljenjeLOC> svaOdeljenja();
        bool upisiNovoOdeljenje(OdeljenjeLOC odeljenjeLoc);
        bool izmeniOdeljenje(OdeljenjeLOC odeljenjeLoc);
        bool traziOdeljenje(string naziv, int sifra_razreda);
    }
}
