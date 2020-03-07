using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IAuthModerator
    {
        bool proveri_validnost(ModeratorLOC moderatorLoc);
    }
}
