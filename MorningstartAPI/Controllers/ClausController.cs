using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MorningstartAPI.Services;

namespace MorningstartAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClausController : ControllerBase
    {
        private readonly ClausService _clausService;
        public ClausController(ClausService clausService)
        {
            _clausService = clausService;
        }

        [HttpGet]
        public async Task<IActionResult> OneRequest()
        {
            var timeElapsed = await _clausService.OneRequest();
            return Ok(timeElapsed);
        }

        [HttpGet]
        public async Task<IActionResult> HundredRequests()
        {
            var timeElapsed = await _clausService.HundredRequests();
            return Ok(timeElapsed);
        }
    }
}
