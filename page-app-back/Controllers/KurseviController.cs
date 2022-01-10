using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using page_app_back.Data.Services;
using page_app_back.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KurseviController : ControllerBase
    {
        private KurseviService _kurseviService;

        public KurseviController(KurseviService kurseviService)
        {
            _kurseviService = kurseviService;
        }

        [HttpGet("dohvati-kurs/{id}")]
        public IActionResult DohvatiKurs(int id)
        {
            var res = _kurseviService.DohvatiKurs(id);
            return Ok(res);
        }
        [HttpGet("dohvati-kurseve")]
        public IActionResult DohvatiKurseve()
        {
            var res = _kurseviService.DohvatiKurseve();
            return Ok(res);
        }

        [HttpPost("dodaj-kurs")]
        public IActionResult DodajKurs([FromBody] KursViewModel kurs)
        {
            _kurseviService.DodajKurs(kurs);
            return Ok();
        }

        [HttpDelete("obrisi-kurs/{id}")]
        public IActionResult ObrisiKurs(int id)
        {
            _kurseviService.ObrisiKurs(id);
            return Ok();
        }
    }
}
