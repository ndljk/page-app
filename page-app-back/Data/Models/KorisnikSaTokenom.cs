using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data.Models
{
    public class KorisnikSaTokenom:Korisnik
    {
        public string Token { get; set; }
        public KorisnikSaTokenom(Korisnik korisnik)
        {
            this.Id = korisnik.Id;
            this.Korisnicko_ime = korisnik.Korisnicko_ime;
        }
    }
}
