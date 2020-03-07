using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class OdeljenjeRepositroy: IOdeljenje
    {

        private HcPortalDbDataContext SkolaEntities;

        public OdeljenjeRepositroy()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool izmeniOdeljenje(OdeljenjeLOC odeljenjeLoc)
        {
           
            bool rezultat_upisa = true;
            bool odeljenje_postoji = traziOdeljenje(odeljenjeLoc.naziv, odeljenjeLoc.razred.sifra_razreda);

            if(odeljenje_postoji == false)
            {
                Odeljenje odeljenje = SkolaEntities.Odeljenjes.FirstOrDefault(o => o.sifra_odeljenja == odeljenjeLoc.sifra_odeljenja);

                odeljenje.naziv = odeljenjeLoc.naziv;
                odeljenje.sifra_razreda = odeljenjeLoc.razred.sifra_razreda;

                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greska pri izmeni odeljenja odeljenja " + e);
                    rezultat_upisa = false;
                }
            }
            else
            {
                rezultat_upisa = false;
            }

            return rezultat_upisa;
        }

        public List<OdeljenjeLOC> svaOdeljenja()
        {
            List<OdeljenjeLOC> sva_odeljenja = new List<OdeljenjeLOC>();

            foreach(var odeljenje in SkolaEntities.Odeljenjes)
            {
                OdeljenjeLOC odeljenjeLoc = new OdeljenjeLOC();
                odeljenjeLoc.sifra_odeljenja = odeljenje.sifra_odeljenja;
                odeljenjeLoc.naziv = odeljenje.naziv;
                odeljenjeLoc.razred = new RazredLOC { sifra_razreda = odeljenje.Razred.sifra_razreda, naziv = odeljenje.Razred.naziv };

                sva_odeljenja.Add(odeljenjeLoc);
            }

            return sva_odeljenja;
        }

        public OdeljenjeLOC traziOdeljenje(int? sifra_odeljenja)
        {
            if (sifra_odeljenja == null)
            {
                return null;
            }
            else
            {
                Odeljenje odeljenje = SkolaEntities.Odeljenjes.FirstOrDefault(o => o.sifra_odeljenja == sifra_odeljenja);
                if (odeljenje == null)
                    return null;

                OdeljenjeLOC odeljenjeLoc = new OdeljenjeLOC
                {
                    sifra_odeljenja = odeljenje.sifra_odeljenja,
                    naziv = odeljenje.naziv,
                    razred = new RazredLOC { sifra_razreda = odeljenje.Razred.sifra_razreda, naziv = odeljenje.Razred.naziv }
                };

                return odeljenjeLoc;
            }
        }

        public bool traziOdeljenje(string naziv, int sifra_razreda)
        {
           bool odeljenje_postoji  = SkolaEntities.Odeljenjes.Any(od => od.naziv == naziv && od.sifra_razreda == sifra_razreda);
           return odeljenje_postoji;
        }

        public bool upisiNovoOdeljenje(OdeljenjeLOC odeljenjeLoc)
        {
            bool rezultat_upisa = true;
            bool odeljenje_postoji = SkolaEntities.Odeljenjes.Any(o => o.naziv == odeljenjeLoc.naziv);


            if(odeljenje_postoji == false)
            {
                Odeljenje odeljenje = new Odeljenje
                {
                    naziv = odeljenjeLoc.naziv,
                    sifra_razreda = odeljenjeLoc.razred.sifra_razreda
                };

                SkolaEntities.Odeljenjes.InsertOnSubmit(odeljenje);

                try
                {
                    SkolaEntities.SubmitChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Greska pri upisu novog odeljenja u bazu " + e);
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