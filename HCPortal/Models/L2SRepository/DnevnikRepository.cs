using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class DnevnikRepository: IDnevnik
    {
        private HcPortalDbDataContext SkolaEntities;

        public DnevnikRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public List<OcenaUcenikaMetaLOC> traziOceneUcenika(int ucenik_sifra, int predmet_sifra)
        {
            var ocene_ucenika = SkolaEntities.UcenikImaOcenus.Where(ou => ou.sifra_ucenika == ucenik_sifra && ou.sifra_predmeta == predmet_sifra).ToList();

            List<OcenaUcenikaMetaLOC> oceneUcenikaLoc = new List<OcenaUcenikaMetaLOC>();

            foreach (var o in ocene_ucenika)
            {
                OcenaUcenikaMetaLOC ocenaLoc = new OcenaUcenikaMetaLOC();

                ocenaLoc.sifra_ucenika = o.sifra_ucenika;
                ocenaLoc.sifra_predmeta = o.sifra_predmeta;
                ocenaLoc.ocena = o.ocena;
                ocenaLoc.polugodiste = o.polugodiste;
                ocenaLoc.opis_prikaz = o.opis;
                ocenaLoc.vreme_upisa = o.vreme_upisa;

                oceneUcenikaLoc.Add(ocenaLoc);
            }

            return oceneUcenikaLoc;
        }

        public List<OdeljenjeLOC> odeljenjaSaRazredom(int razred)
        {

            var odeljenja = SkolaEntities.Odeljenjes.Where(o => o.sifra_razreda == razred);
            List<OdeljenjeLOC> sva_odeljenja = new List<OdeljenjeLOC>();

            foreach (var o in odeljenja)
            {
                OdeljenjeLOC odeljenjeLoc = new OdeljenjeLOC();
                odeljenjeLoc.naziv = o.naziv;
                odeljenjeLoc.sifra_odeljenja = o.sifra_odeljenja;
                sva_odeljenja.Add(odeljenjeLoc);
            }
            return sva_odeljenja;
        }

        public List<PredmetLOC> predmetiUcenika(int ucenik_sifra)
        {
            var ucenik_ = SkolaEntities.Uceniks.FirstOrDefault(u => u.sifra_ucenika == ucenik_sifra);
            int sifra_odeljenja = ucenik_.sifra_odeljenja;

            var odeljenje = SkolaEntities.Odeljenjes.FirstOrDefault(o => o.sifra_odeljenja == sifra_odeljenja);
            var sifre_predmeta = SkolaEntities.RazredImaPredmets.Where(rp => rp.sifra_razreda == odeljenje.sifra_razreda).Select(rp => rp.sifra_predmeta);

            List<PredmetLOC> svi_predmeti = new List<PredmetLOC>();

            foreach (var sifra in sifre_predmeta)
            {
                var predmet = SkolaEntities.Predmets.FirstOrDefault(p => p.sifra_predmeta == sifra);

                PredmetLOC predmetLoc = new PredmetLOC();
                predmetLoc.sifra_predmeta = predmet.sifra_predmeta;
                predmetLoc.naziv = predmet.naziv;
                svi_predmeti.Add(predmetLoc);

            }

            return svi_predmeti;
  
        }

        public List<UcenikLOC> uceniciIzOdeljenja(int odeljenje)
        {
            var ucenici = SkolaEntities.Uceniks.Where(u => u.sifra_odeljenja == odeljenje);
            List<UcenikLOC> svi_ucenici = new List<UcenikLOC>();

            foreach(var u in ucenici)
            {
                UcenikLOC ucenikLoc = new UcenikLOC();
                ucenikLoc.sifra_ucenika = u.sifra_ucenika;
                ucenikLoc.ime = u.ime;
                ucenikLoc.prezime = u.prezime;
                ucenikLoc.jmbg = u.jmbg;
                ucenikLoc.korisnicko_ime = u.korisnicko_ime;
                svi_ucenici.Add(ucenikLoc);
            }
            return svi_ucenici;
        }

        public bool upisOceneUceniku(OcenaUcenikaMetaLOC ocenaUcenikaMetaLoc)
        {
            bool rezultat_upita = true;
            string opis_ocene = "";

            switch(ocenaUcenikaMetaLoc.opis)
            {
                case 1:
                    opis_ocene = "Kontrolni zadatak";
                    break;
                case 2:
                    opis_ocene = "Pismeni zadatak";
                    break;
                case 3:
                    opis_ocene = "Usmeno odgovaranje";
                    break;
                case 4:
                    opis_ocene = "Aktivnost na nastavi";
                    break;
            }


            UcenikImaOcenu ucenikOcena = new UcenikImaOcenu
            {
                sifra_ucenika = ocenaUcenikaMetaLoc.sifra_ucenika,
                sifra_predmeta = ocenaUcenikaMetaLoc.sifra_predmeta,
                ocena = ocenaUcenikaMetaLoc.ocena,
                polugodiste = ocenaUcenikaMetaLoc.polugodiste,
                opis = opis_ocene,
                vreme_upisa = DateTime.Now.ToString()
            };

            SkolaEntities.UcenikImaOcenus.InsertOnSubmit(ucenikOcena);

            try
            {
                SkolaEntities.SubmitChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska pri upisu ocene u bazu " + e);
                rezultat_upita = false;
            }


            return rezultat_upita;
        }
    }
}