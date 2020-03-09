using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using HCPortal.Models.RepositoryInterfaces;

namespace HCPortal.Models.L2SRepository
{
    public class AuthModeratorRepository : IAuthModerator
    {
        private HcPortalDbDataContext SkolaEntities;

        public AuthModeratorRepository()
        {
            SkolaEntities = new HcPortalDbDataContext();
        }

        public bool proveri_validnost(ModeratorLOC moderatorLoc)
        {
            bool validan = false;

            bool moderator_postoji = SkolaEntities.Moderators.Any(m => m.korisnicko_ime == moderatorLoc.korisnicko_ime);


            if (moderator_postoji)
            {
                var moderator = SkolaEntities.Moderators.FirstOrDefault(m => m.korisnicko_ime == moderatorLoc.korisnicko_ime);

                byte[] data = Encoding.UTF8.GetBytes(moderatorLoc.sifra);
                byte[] sha512Data = SHA512.Create().ComputeHash(data);
                string sifraZaProveru = Convert.ToBase64String(sha512Data);


                if (sifraZaProveru == moderator.sifra)
                {
                    validan = true;
                }
            }

            return validan;
        }
    }
}