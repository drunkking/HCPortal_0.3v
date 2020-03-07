using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IDnevnik
    {
        List<OdeljenjeLOC> odeljenjaSaRazredom(int razred);
        List<UcenikLOC> uceniciIzOdeljenja(int odeljenje);
        List<PredmetLOC> predmetiUcenika(int ucenik_sifra);
        List<OcenaUcenikaMetaLOC> traziOceneUcenika(int ucenik_sifra, int predmet_sifra);
        bool upisOceneUceniku(OcenaUcenikaMetaLOC ocenaUcenikaMetaLoc);
    }
}
