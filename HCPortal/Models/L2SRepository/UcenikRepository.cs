using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class UcenikRepository: IUcenik
    {
        private HcPortalDbDataContext SkolaEntities;

        public UcenikRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool izmeniUcenika(UcenikLOC ucenikLoc)
        {
            bool rezultat_upisa = true;
            Ucenik ucenik_ = SkolaEntities.Uceniks.FirstOrDefault(u => u.sifra_ucenika == ucenikLoc.sifra_ucenika);

            if(ucenik_.korisnicko_ime != ucenikLoc.korisnicko_ime)
            {
                bool ucenik_postoji = traziUcenika(ucenikLoc.korisnicko_ime);

                if(ucenik_postoji == false)
                {
                    Ucenik ucenik = SkolaEntities.Uceniks.FirstOrDefault(u => u.sifra_ucenika == ucenikLoc.sifra_ucenika);
                    ucenik.ime = ucenikLoc.ime;
                    ucenik.prezime = ucenikLoc.prezime;
                    ucenik.korisnicko_ime = ucenikLoc.korisnicko_ime;
                    ucenik.datum_rodjenja = ucenikLoc.datum_rodjenja;
                    ucenik.mesto_stanovanja = ucenikLoc.mesto_stanovanja;
                    ucenik.jmbg = ucenikLoc.jmbg;
                    ucenik.ime_staratelja = ucenikLoc.ime_staratelja;
                    ucenik.prezime_staratelja = ucenikLoc.prezime_staratelja;
                    ucenik.kontakt_telefon = ucenikLoc.kontakt_telefon;
                    ucenik.sifra_odeljenja = ucenikLoc.odeljenje.sifra_odeljenja;


                    try
                    {
                        SkolaEntities.SubmitChanges();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Greska pri upisu ucenika u bazu: " + e);
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
                Ucenik ucenik = SkolaEntities.Uceniks.FirstOrDefault(u => u.sifra_ucenika == ucenikLoc.sifra_ucenika);
                ucenik.ime = ucenikLoc.ime;
                ucenik.prezime = ucenikLoc.prezime;
                ucenik.korisnicko_ime = ucenikLoc.korisnicko_ime;
                ucenik.datum_rodjenja = ucenikLoc.datum_rodjenja;
                ucenik.mesto_stanovanja = ucenikLoc.mesto_stanovanja;
                ucenik.jmbg = ucenikLoc.jmbg;
                ucenik.ime_staratelja = ucenikLoc.ime_staratelja;
                ucenik.prezime_staratelja = ucenikLoc.prezime_staratelja;
                ucenik.kontakt_telefon = ucenikLoc.kontakt_telefon;
                ucenik.sifra_odeljenja = ucenikLoc.odeljenje.sifra_odeljenja;


                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greska pri upisu ucenika u bazu: " + e);
                    rezultat_upisa = false;

                }
            }



            return rezultat_upisa;
        }

        public List<UcenikLOC> sviUcenici()
        {
            List<UcenikLOC> svi_ucenici = new List<UcenikLOC>();

            foreach(var ucenik in SkolaEntities.Uceniks)
            {
                UcenikLOC ucenikLoc = new UcenikLOC
                {
                    sifra_ucenika = ucenik.sifra_ucenika,
                    odeljenje = new OdeljenjeLOC {
                        sifra_odeljenja = ucenik.Odeljenje.sifra_odeljenja,
                        naziv = ucenik.Odeljenje.naziv,
                        razred = new RazredLOC { sifra_razreda = ucenik.Odeljenje.Razred.sifra_razreda, naziv = ucenik.Odeljenje.Razred.naziv }
                    },
                    ime = ucenik.ime,
                    prezime = ucenik.prezime,
                    korisnicko_ime = ucenik.korisnicko_ime,
                    datum_rodjenja = ucenik.datum_rodjenja,

                };
                svi_ucenici.Add(ucenikLoc);
            }
            return svi_ucenici;
        }

        public UcenikLOC traziUcenika(int? sifra_ucenika)
        {
            if(sifra_ucenika == null)
            {
                return null;
            }
            else
            {
                Ucenik ucenik = SkolaEntities.Uceniks.FirstOrDefault(m => m.sifra_ucenika == sifra_ucenika);
                if (ucenik == null)
                    return null;


                UcenikLOC ucenikLoc = new UcenikLOC
                {
                    sifra_ucenika = ucenik.sifra_ucenika,
                    odeljenje = new OdeljenjeLOC
                    {
                        sifra_odeljenja = ucenik.Odeljenje.sifra_odeljenja,
                        naziv = ucenik.Odeljenje.naziv,
                        razred = new RazredLOC { sifra_razreda = ucenik.Odeljenje.Razred.sifra_razreda, naziv = ucenik.Odeljenje.Razred.naziv }
                    },
                    ime = ucenik.ime,
                    prezime = ucenik.prezime,
                    korisnicko_ime = ucenik.korisnicko_ime,
                    datum_rodjenja = ucenik.datum_rodjenja,
                    mesto_stanovanja = ucenik.mesto_stanovanja,
                    jmbg = ucenik.jmbg,
                    ime_staratelja = ucenik.ime_staratelja,
                    prezime_staratelja = ucenik.prezime_staratelja,
                    kontakt_telefon = ucenik.kontakt_telefon
                };
                return ucenikLoc;
            }
        }

        public bool traziUcenika(string korisnicko_ime)
        {
            bool ucenik_postoji = SkolaEntities.Uceniks.Any(m => m.korisnicko_ime == korisnicko_ime);
            return ucenik_postoji;
        }

        public bool upisiNovogUcenika(UcenikLOC ucenikLoc)
        {
            bool rezultat_upisa = true;
            bool ucenik_postoji = traziUcenika(ucenikLoc.korisnicko_ime);


            if (ucenik_postoji == false)
            {

                byte[] data = Encoding.UTF8.GetBytes(ucenikLoc.sifra);
                byte[] sha512Data = SHA512.Create().ComputeHash(data);
                string sifraZaSkladistenje = Convert.ToBase64String(sha512Data);

                Ucenik ucenik = new Ucenik
                {
                    sifra_odeljenja = ucenikLoc.odeljenje.sifra_odeljenja,
                    ime = ucenikLoc.ime,
                    prezime = ucenikLoc.prezime,
                    korisnicko_ime = ucenikLoc.korisnicko_ime,
                    sifra = sifraZaSkladistenje,
                    datum_rodjenja = ucenikLoc.datum_rodjenja,
                    mesto_stanovanja = ucenikLoc.mesto_stanovanja,
                    jmbg = ucenikLoc.mesto_stanovanja,
                    ime_staratelja = ucenikLoc.ime_staratelja,
                    prezime_staratelja = ucenikLoc.prezime_staratelja,
                    kontakt_telefon = ucenikLoc.prezime_staratelja
                };

                SkolaEntities.Uceniks.InsertOnSubmit(ucenik);
            
                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Greska pri upisu novog ucenika u bazu " + e);
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