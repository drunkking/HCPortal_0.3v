using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class ProfesorRepository: IProfesor
    {
        private HcPortalDbDataContext SkolaEntities;

        public ProfesorRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool izmeniProfesora(ProfesorLOC profesorLoc)
        {
            bool rezultat_upisa = true;
            Profesor profesor_ = SkolaEntities.Profesors.FirstOrDefault(p => p.sifra_profesora == profesorLoc.sifra_profesora);

            if(profesor_.jmbg != profesorLoc.jmbg)
            {
                bool profesor_postoji = traziProfesora(profesorLoc.jmbg);

                if (profesor_postoji == false)
                {
                    Profesor profesor = SkolaEntities.Profesors.FirstOrDefault(p => p.sifra_profesora == profesorLoc.sifra_profesora);
                    profesor.ime = profesorLoc.ime;
                    profesor.prezime = profesorLoc.prezime;
                    profesor.datum_rodjenja = profesorLoc.datum_rodjenja;
                    profesor.mesto_stanovanja = profesorLoc.mesto_stanovanja;
                    profesor.jmbg = profesorLoc.jmbg;

                    try
                    {
                        SkolaEntities.SubmitChanges();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Greska pri upisu profesora u bazu " + e);
                        rezultat_upisa = false;
                    }


                }
                else
                {
                    rezultat_upisa = false;
                }
            }
            else
            {
                Profesor profesor = SkolaEntities.Profesors.FirstOrDefault(p => p.sifra_profesora == profesorLoc.sifra_profesora);
                profesor.ime = profesorLoc.ime;
                profesor.prezime = profesorLoc.prezime;
                profesor.datum_rodjenja = profesorLoc.datum_rodjenja;
                profesor.mesto_stanovanja = profesorLoc.mesto_stanovanja;

                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greska pri upisu profesora u bazu " + e);
                    rezultat_upisa = false;
                }
            }


            return rezultat_upisa;
        }

        public List<ProfesorLOC> sviProfesori()
        {
            List<ProfesorLOC> svi_profesori = new List<ProfesorLOC>();

            foreach(var profesor in SkolaEntities.Profesors)
            {
                ProfesorLOC profesorLoc = new ProfesorLOC
                {
                    sifra_profesora = profesor.sifra_profesora,
                    ime = profesor.ime,
                    prezime = profesor.prezime,
                    datum_rodjenja = profesor.datum_rodjenja,
                    mesto_stanovanja = profesor.mesto_stanovanja,
                    jmbg = profesor.jmbg
                };

                svi_profesori.Add(profesorLoc);
            }

            return svi_profesori;
        }

        public ProfesorLOC traziProfesora(int? sifra_profesora)
        {
            if(sifra_profesora == null)
            {
                return null;
            }
            else
            {
                Profesor profesor = SkolaEntities.Profesors.FirstOrDefault(m => m.sifra_profesora == sifra_profesora);
                if (profesor == null)
                    return null;

                ProfesorLOC profesorLoc = new ProfesorLOC
                {
                    sifra_profesora = profesor.sifra_profesora,
                    ime = profesor.ime,
                    prezime = profesor.prezime,
                    datum_rodjenja = profesor.datum_rodjenja,
                    mesto_stanovanja = profesor.mesto_stanovanja,
                    jmbg = profesor.jmbg
                };

                return profesorLoc;
            }
        }

        public bool traziProfesora(string jmbg)
        {
            bool profesor_postoji = SkolaEntities.Profesors.Any(p => p.jmbg == jmbg);
            return profesor_postoji;
        }

        public bool upisiNovogProfesora(ProfesorLOC profesorLoc)
        {
            bool rezultat_upisa = true;
            bool profesor_postoji = traziProfesora(profesorLoc.jmbg);

            if(profesor_postoji == false)
            {
                Profesor profesor = new Profesor
                {
                    sifra_profesora = GetHashCode(),
                    ime = profesorLoc.ime,
                    prezime = profesorLoc.prezime,
                    datum_rodjenja = profesorLoc.datum_rodjenja,
                    mesto_stanovanja = profesorLoc.mesto_stanovanja,
                    jmbg = profesorLoc.jmbg
                };

                SkolaEntities.Profesors.InsertOnSubmit(profesor);

                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Greska pri upisu nogo moderatora u bazu " + e);
                    rezultat_upisa = false;
                }
            }
            else
            {
                rezultat_upisa = false;
            }

            return rezultat_upisa;
        }
    }
}