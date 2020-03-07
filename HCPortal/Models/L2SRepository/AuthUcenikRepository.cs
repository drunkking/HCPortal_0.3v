using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class AuthUcenikRepository : IAuthUcenik
    {
        private HcPortalDbDataContext SkolaEntities;

        public AuthUcenikRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool proveri_validnost(UcenikLOC ucenikLoc)
        {
            bool validan = false;

            var moderator = SkolaEntities.Uceniks.FirstOrDefault(u => u.korisnicko_ime == ucenikLoc.korisnicko_ime);

            byte[] data = Encoding.UTF8.GetBytes(ucenikLoc.sifra);
            byte[] sha512Data = SHA512.Create().ComputeHash(data);
            string sifraZaProveru = Convert.ToBase64String(sha512Data);


            if (sifraZaProveru == moderator.sifra)
            {
                validan = true;
            }


            return validan;
        }
    }
}