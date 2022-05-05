using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPL.Models;
using EPL.ViewModels;

namespace EPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IDivisionRepository divisionRepository;

        public HomeController(ILogger<HomeController> logger, IPlayerRepository playerRepository, ITeamRepository teamRepository, IDivisionRepository divisionRepository)
        {
            _logger = logger;
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
            this.divisionRepository = divisionRepository;
        }

        public IActionResult Index(HomeIndexViewModel homeIndexViewModel)
        {   
            var players = playerRepository.GetPlayersByName(homeIndexViewModel.SearchTerm);
            var teams = teamRepository.GetTeamsByName(homeIndexViewModel.SearchTerm, null);
            var divisions = divisionRepository.GetDivisionByName(homeIndexViewModel.SearchTerm);
            return View(new HomeIndexViewModel
            {
                Players = players,
                Teams = teams,
                Divisions = divisions
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

