using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using nuelranks.pustalorc.xyz.JSON_Classes;
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

        [Route("{tournament}/")]
        public IActionResult Tournament(string tournament)
        {
            using (var web = new WebClient())
            {
                var tournaments =
                    JsonConvert.DeserializeObject<List<Tournament>>(
                        web.DownloadString("https://api.pustalorc.xyz/NuelTeams"));
                ViewBag.Tournament = tournaments.FirstOrDefault(k =>
                    k.TournamentName.Equals(tournament, StringComparison.InvariantCultureIgnoreCase));
                return View();
            }
        }

        [HttpGet("{tournament}/{team}")]
        public IActionResult TournamentTeam(string tournament, string team)
        {
            using (var web = new WebClient())
            {
                var tournaments =
                    JsonConvert.DeserializeObject<List<Tournament>>(
                        web.DownloadString("https://api.pustalorc.xyz/NuelTeams"));
                ViewBag.Tournament = tournaments.FirstOrDefault(k =>
                    k.TournamentName.Equals(tournament, StringComparison.InvariantCultureIgnoreCase));
                ViewBag.TeamID = team;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}