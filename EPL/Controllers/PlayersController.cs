using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EPL.Models;
using EPL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EPL.Controllers
{
	public class PlayersController : Controller
	{
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;

        [TempData]
        public string message { get; set; }

        public PlayersController(IPlayerRepository playerRepository, ITeamRepository teamRepository)
		{
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }

        public IActionResult List(PlayersListViewModel playersListViewModel)
        {
            var players = playerRepository.GetPlayersByName(playersListViewModel.SearchTerm);

            return View(new PlayersListViewModel
            {
                Players = players,
                Message = message
            });
        }

        
	}
}

