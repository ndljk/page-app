using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using page_app_back.Data;
using page_app_back.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace page_app_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JWTSettings _jwtsettings;

        public KorisniciController(AppDbContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        [HttpPost("login")]
        public async Task<ActionResult<KorisnikSaTokenom>> Login([FromBody] Korisnik korisnik)
        {
            korisnik = await _context.Korisnici.Where(k => k.Korisnicko_ime == korisnik.Korisnicko_ime
                                                && k.Lozinka == korisnik.Lozinka).FirstOrDefaultAsync();

            if (korisnik == null)
            {
                return NotFound();
            }

            KorisnikSaTokenom korisnikSaTokenom = new KorisnikSaTokenom(korisnik);

            

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, korisnik.Korisnicko_ime)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            //tokenHandler kreira token na osnovu opisa (tokenDescriptor)
            var token = tokenHandler.CreateToken(tokenDescriptor); 
            korisnikSaTokenom.Token = tokenHandler.WriteToken(token);

            return korisnikSaTokenom;
        }
    }
}
