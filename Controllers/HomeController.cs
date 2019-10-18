using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nuelranks.pustalorc.xyz.Models;

namespace nuelranks.pustalorc.xyz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("LoL/")]
        public IActionResult LeagueOfLegends()
        {
            return View();
        }

        [HttpGet("LoL/{team}")]
        public IActionResult LeagueOfLegendsTeam(string team)
        {
            ViewBag.Message = team;
            return View();
        }

        [Route("R6/")]
        public IActionResult RainbowSix()
        {
            return View();
        }

        [HttpGet("R6/{team}")]
        public IActionResult RainbowSixTeam(string team)
        {
            ViewBag.Message = team;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}