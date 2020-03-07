using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IAuthUcenik
    {
        bool proveri_validnost(UcenikLOC ucenikLoc);
    }
}
