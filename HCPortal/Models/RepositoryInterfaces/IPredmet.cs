using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IPredmet
    {
        PredmetLOC traziPredmet(int? sifra_predmeta);
        List<PredmetLOC> sviPredmeti();
        bool upisiNoviPredmet(PredmetLOC predmetLoc, int[] razredi);
        bool izmeniPredmet(PredmetLOC predmetLoc, int[] razredi);
        bool traziPredmet(string naziv);
    }
}
