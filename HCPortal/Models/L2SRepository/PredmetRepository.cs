using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class PredmetRepository: IPredmet
    {
        private HcPortalDbDataContext SkolaEntities;

        public PredmetRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool izmeniPredmet(PredmetLOC predmetLoc,int[] razredi)
        {

            bool rezultat_upisa = true;
            Predmet predmet_ = SkolaEntities.Predmets.FirstOrDefault(p => p.sifra_predmeta == predmetLoc.sifra_predmeta);


            if(predmet_.naziv != predmetLoc.naziv)
            {
                bool predmet_postoji = traziPredmet(predmetLoc.naziv);

                if (predmet_postoji == false)
                {
                    if (razredi.Count() != 0)
                    {
                        try
                        {
                            Predmet predmet = SkolaEntities.Predmets.FirstOrDefault(p => p.sifra_predmeta == predmetLoc.sifra_predmeta);
                            predmet.naziv = predmetLoc.naziv;


                            var razredPredmet = SkolaEntities.RazredImaPredmets.Where(r => r.sifra_predmeta == predmetLoc.sifra_predmeta);
                            foreach (var rp in razredPredmet)
                            {
                                SkolaEntities.RazredImaPredmets.DeleteOnSubmit(rp);
                            }

                            foreach (var razred_s in razredi)
                            {
                                RazredImaPredmet razredImaPredmet = new RazredImaPredmet
                                {
                                    sifra_predmeta = predmet.sifra_predmeta,
                                    sifra_razreda = razred_s
                                };

                                SkolaEntities.RazredImaPredmets.InsertOnSubmit(razredImaPredmet);
                            }
                            SkolaEntities.SubmitChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Greska pri upisu novog predmeta u bazu " + e);
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
                    rezultat_upisa = false;
                }
            }
            else
            {
                if (razredi.Count() != 0)
                {
                    try
                    {
                        Predmet predmet = SkolaEntities.Predmets.FirstOrDefault(p => p.sifra_predmeta == predmetLoc.sifra_predmeta);

                        var razredPredmet = SkolaEntities.RazredImaPredmets.Where(r => r.sifra_predmeta == predmetLoc.sifra_predmeta);
                        foreach (var rp in razredPredmet)
                        {
                            SkolaEntities.RazredImaPredmets.DeleteOnSubmit(rp);
                        }

                        foreach (var razred_s in razredi)
                        {
                            RazredImaPredmet razredImaPredmet = new RazredImaPredmet
                            {
                                sifra_predmeta = predmet.sifra_predmeta,
                                sifra_razreda = razred_s
                            };

                            SkolaEntities.RazredImaPredmets.InsertOnSubmit(razredImaPredmet);
                        }
                        SkolaEntities.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Greska pri upisu novog predmeta u bazu " + e);
                        rezultat_upisa = false;
                    }
                }
                else
                {
                    rezultat_upisa = false;
                }
            }


            return rezultat_upisa;
        }

        public List<PredmetLOC> sviPredmeti()
        {
            List<PredmetLOC> svi_predmeti = new List<PredmetLOC>();

            foreach(var predmet in SkolaEntities.Predmets)
            {
                PredmetLOC predmetLoc = new PredmetLOC();
                predmetLoc.naziv = predmet.naziv;
                predmetLoc.sifra_predmeta = predmet.sifra_predmeta;

                List<RazredLOC> svi_razredi = new List<RazredLOC>();
               
                var razredi = predmet.RazredImaPredmets.Where(r => r.sifra_predmeta == predmet.sifra_predmeta);

                foreach(var razred in razredi)
                {
                    RazredLOC razredLoc = new RazredLOC();
                    razredLoc.sifra_razreda = razred.sifra_razreda;
                    svi_razredi.Add(razredLoc);
                }

                foreach(var razredLoc in svi_razredi)
                {
                    razredLoc.naziv = SkolaEntities.Razreds.Where(r => r.sifra_razreda == razredLoc.sifra_razreda).Select(r => r.naziv).Single();
                }

                predmetLoc.razredi = svi_razredi;
                svi_predmeti.Add(predmetLoc);
            }

            return svi_predmeti;
        }

        public PredmetLOC traziPredmet(int? sifra_predmeta)
        {
            if(sifra_predmeta == null)
            {
                return null;
            }
            else
            {
                Predmet predmet = SkolaEntities.Predmets.FirstOrDefault(p => p.sifra_predmeta == sifra_predmeta);
                if (predmet == null)
                    return null;

                List<RazredLOC> svi_razredi = new List<RazredLOC>();
                var razredi = predmet.RazredImaPredmets.Where(r => r.sifra_predmeta == predmet.sifra_predmeta);

                foreach(var razred in razredi)
                {
                    RazredLOC razredLoc = new RazredLOC();
                    razredLoc.sifra_razreda = razred.sifra_razreda;
                    svi_razredi.Add(razredLoc);
                }

                PredmetLOC predmetLoc = new PredmetLOC
                {
                    naziv = predmet.naziv,
                    sifra_predmeta = predmet.sifra_predmeta,
                    razredi = svi_razredi
                };
                return predmetLoc;
            }
        }

        public bool traziPredmet(string naziv)
        {
          bool predmet_postoji = SkolaEntities.Predmets.Any(p => p.naziv == naziv);
          return predmet_postoji;
        }

        public bool upisiNoviPredmet(PredmetLOC predmetLoc, int[] razredi)
        {
            bool rezultat_upisa = true;
            bool predmet_postoji = SkolaEntities.Predmets.Any(p => p.naziv == predmetLoc.naziv);


            if(predmet_postoji == false)
            {
                if(razredi.Count() != 0)
                {

                    try { 
                        Predmet predmet = new Predmet
                        {
                            naziv = predmetLoc.naziv
                        };
                                              
                        SkolaEntities.Predmets.InsertOnSubmit(predmet);
                        SkolaEntities.SubmitChanges();


                        foreach (var razred_s in razredi)
                        {
                            RazredImaPredmet razredImaPredmet = new RazredImaPredmet
                            {
                                sifra_predmeta = predmet.sifra_predmeta,
                                sifra_razreda = razred_s
                            };


                            SkolaEntities.RazredImaPredmets.InsertOnSubmit(razredImaPredmet);
                        }                                          
                        SkolaEntities.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Greska pri upisu novog predmeta u bazu " + e);
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
                rezultat_upisa = false;
            }

            return rezultat_upisa;
        }
    }
}