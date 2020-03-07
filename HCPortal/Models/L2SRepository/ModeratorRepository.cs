using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class ModeratorRepository: IModerator
    {
        private HcPortalDbDataContext SkolaEntities;

        public ModeratorRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool izmeniModeratora(ModeratorLOC moderatorLoc)
        {
            bool rezultat_upisa = true;
            Moderator moderator_ = SkolaEntities.Moderators.FirstOrDefault(p => p.sifra_moderatora == moderatorLoc.sifra_moderatora);

            if(moderator_.korisnicko_ime != moderatorLoc.korisnicko_ime)
            {
                bool moderator_postoji = traziModeratora(moderatorLoc.korisnicko_ime);

                if (moderator_postoji == false)
                {
                    Moderator moderator = SkolaEntities.Moderators.FirstOrDefault(m => m.sifra_moderatora == moderatorLoc.sifra_moderatora);
                    moderator.ime = moderatorLoc.ime;
                    moderator.prezime = moderatorLoc.prezime;
                    moderator.korisnicko_ime = moderatorLoc.korisnicko_ime;
                    moderator.datum_rodjenja = moderatorLoc.datum_rodjenja;

                    try
                    {
                        SkolaEntities.SubmitChanges();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Greska pri upisu moderatora u bazu " + e);
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
                Moderator moderator = SkolaEntities.Moderators.FirstOrDefault(m => m.sifra_moderatora == moderatorLoc.sifra_moderatora);
                moderator.ime = moderatorLoc.ime;
                moderator.prezime = moderatorLoc.prezime;
                moderator.datum_rodjenja = moderatorLoc.datum_rodjenja;

                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greska pri upisu moderatora u bazu " + e);
                    rezultat_upisa = false;
                }
            }


            return rezultat_upisa;
        
        }

        public List<ModeratorLOC> sviModeratori()
        {
            List<ModeratorLOC> svi_moderatori = new List<ModeratorLOC>();

            foreach(var moderator in SkolaEntities.Moderators)
            {
                ModeratorLOC moderatorLoc = new ModeratorLOC
                {
                    sifra_moderatora = moderator.sifra_moderatora,
                    ime = moderator.ime,
                    prezime = moderator.prezime,
                    korisnicko_ime = moderator.korisnicko_ime,
                    datum_rodjenja = moderator.datum_rodjenja
                };

                svi_moderatori.Add(moderatorLoc);
            }

            return svi_moderatori;
        }

        public ModeratorLOC traziModeratora(int? sifra_moderatora)
        {
            if(sifra_moderatora == null)
            {
                return null;
            }
            else
            {
                Moderator moderator = SkolaEntities.Moderators.FirstOrDefault(m => m.sifra_moderatora == sifra_moderatora);
                if (moderator == null)
                    return null;

                ModeratorLOC moderatorLoc = new ModeratorLOC
                {
                    sifra_moderatora = moderator.sifra_moderatora,
                    ime = moderator.ime,
                    prezime = moderator.prezime,
                    korisnicko_ime = moderator.korisnicko_ime,
                    datum_rodjenja = moderator.datum_rodjenja
                };

                return moderatorLoc;
            }
        }

        public bool traziModeratora(string korisnicko_ime)
        {
            bool moderator_postoji = SkolaEntities.Moderators.Any(m => m.korisnicko_ime == korisnicko_ime);
            return moderator_postoji;
        }

        public bool upisiNovogModerator(ModeratorLOC moderatorLoc)
        {
            bool rezultat_upisa = true;
            bool moderator_postoji = traziModeratora(moderatorLoc.korisnicko_ime);

            if(moderator_postoji == false)
            {

                byte[] data = Encoding.UTF8.GetBytes(moderatorLoc.sifra);
                byte[] sha512Data = SHA512.Create().ComputeHash(data);
                string sifraZaSkladistenje = Convert.ToBase64String(sha512Data);

                Moderator moderator = new Moderator
                {
                    ime = moderatorLoc.ime,
                    prezime = moderatorLoc.prezime,
                    korisnicko_ime = moderatorLoc.korisnicko_ime,
                    sifra = sifraZaSkladistenje,
                    datum_rodjenja = moderatorLoc.datum_rodjenja
                };

                SkolaEntities.Moderators.InsertOnSubmit(moderator);

                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Greska pri upisu novog moderatora u bazu " + e);
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