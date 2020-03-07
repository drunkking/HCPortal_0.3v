using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IModerator
    {
        ModeratorLOC traziModeratora(int? sifra_moderatora);
        List<ModeratorLOC> sviModeratori();
        bool upisiNovogModerator(ModeratorLOC moderatorLoc);
        bool izmeniModeratora(ModeratorLOC moderatorLoc);
        bool traziModeratora(string korisnicko_ime);
    }
}
