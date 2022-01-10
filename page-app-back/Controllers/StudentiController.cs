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
    public class StudentiController : ControllerBase
    {
        public StudentiService _studentiService;
        public StudentiController(StudentiService studentiService)
        {
            _studentiService = studentiService;
        }

        [HttpGet("dohvati-studente")]
        public IActionResult DohvatiSveStudente()
        {
            var studenti = _studentiService.DohvatiSveStudente();
            return Ok(studenti);
        }

        [HttpGet("dohvati-studenta/{id}")]
        public IActionResult DohvatiStudent(int id)
        {
            var student = _studentiService.DohvatiStudenta(id);
            return Ok(student);
        }

        [HttpPost("dodaj-studenta")]
        public IActionResult DodajStudenta([FromBody]StudentViewModel student)
        {
            _studentiService.DodajStudenta(student);
            return Ok();
        }

        [HttpPut("update-studenta/{id}")]
        public IActionResult UpdateStudenta(int id, [FromBody] StudentViewModel student)
        {
            var updatedStudent = _studentiService.UpdateStudenta(id, student);
            return Ok(updatedStudent);
        }

        [HttpDelete("obrisi-studenta/{id}")]
        public IActionResult ObrisiStudenta(int id)
        {
            _studentiService.ObrisiStudenta(id);
            return Ok();
        }
    }
}
