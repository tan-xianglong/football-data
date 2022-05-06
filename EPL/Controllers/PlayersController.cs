using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EPL.Models;
using EPL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EPL.Controllers
{
	public class PlayersController : Controller
	{
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IHtmlHelper htmlHelper;

        [TempData]
        public string message { get; set; }

        public PlayersController(IPlayerRepository playerRepository, ITeamRepository teamRepository, IHtmlHelper htmlHelper)
		{
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
            this.htmlHelper = htmlHelper;
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

        public IActionResult Details(int playerId)
        {
            var player = playerRepository.GetPlayerById(playerId);

            return View(player);
        }

        [Authorize]
        public IActionResult Edit(int? playerId)
        {
            Player player;
            string header;
            IEnumerable<Team> teams = teamRepository.GetTeamsByName(null, null);
            IEnumerable<SelectListItem> positions = htmlHelper.GetEnumSelectList<Position>();

            if(!playerId.HasValue)
            {
                player = new Player();
                header = "Add New";
            }
            else
            {
                player = playerRepository.GetPlayerById(playerId.Value);
                header = "Edit";
            }

            if(player == null)
            {
                return NotFound();
            }

            return View(new PlayersEditViewModel
            {
                Player = player,
                Header = header,
                Teams = teams,
                Positions = positions
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if(player.PlayerId > 0)
            {
                playerRepository.Update(player);
            }
            else
            {
                playerRepository.Add(player);
            }
            playerRepository.Commit();
            TempData["message"] = "Player saved!";
            return RedirectToAction("List");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int playerId)
        {
            //to add existing player check in the future
            var player = playerRepository.Delete(playerId);
            playerRepository.Commit();
            if (player == null)
            {
                return NotFound();
            }

            TempData["Message"] = $"{player.Name} deleted.";
            return RedirectToAction("List");
        }
    }
}

