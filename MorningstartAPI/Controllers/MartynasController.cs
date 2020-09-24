using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MorningstartAPI.Services;

namespace MorningstartAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MartynasController : ControllerBase
    {
        private readonly MartynasService _martynasService;
        public MartynasController(MartynasService martynasService)
        {
            _martynasService = martynasService;
        }

        [HttpGet]
        public async Task<IActionResult> OneRequest()
        {
            var timeElapsed = await _martynasService.OneRequest();
            return Ok(timeElapsed);
        }

        [HttpGet]
        public async Task<IActionResult> HundredRequests()
        {
            var timeElapsed = await _martynasService.HundredRequests();
            return Ok(timeElapsed);
        }
    }
}
