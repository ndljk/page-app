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
    public class StatusiController : ControllerBase
    {
        public StatusiService _statusiService;
        public StatusiController(StatusiService statusiService)
        {
            _statusiService = statusiService;
        }

        [HttpGet("dohvati-statuse")]
        public IActionResult DohvatiStatuse()
        {
            var statusi=_statusiService.DohvatiStatuse();
            return Ok(statusi);
        }
    }
}
