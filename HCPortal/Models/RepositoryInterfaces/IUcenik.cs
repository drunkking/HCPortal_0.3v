using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IUcenik
    {
        UcenikLOC traziUcenika(int? sifra_ucenika);
        List<UcenikLOC> sviUcenici();
        bool upisiNovogUcenika(UcenikLOC ucenikLoc);
        bool izmeniUcenika(UcenikLOC ucenikLoc);
        bool traziUcenika(string korisnicko_ime);
    }
}
