using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCPortal.Models.RepositoryInterfaces
{
    interface IProfesor
    {
        ProfesorLOC traziProfesora(int? sifra_profesora);
        List<ProfesorLOC> sviProfesori();
        bool upisiNovogProfesora(ProfesorLOC profesorLoc);
        bool izmeniProfesora(ProfesorLOC profesorLoc);
        bool traziProfesora(string jmbg);
    }
}
