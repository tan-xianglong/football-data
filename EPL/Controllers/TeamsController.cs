using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPL.Models;
using EPL.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EPL.Controllers
{
	public class TeamsController : Controller
	{
        private readonly ITeamRepository teamRepository;

        [TempData]
        public string message { get; set; }

        public TeamsController(ITeamRepository teamRepository)
		{
            this.teamRepository = teamRepository;
        }

        public IActionResult List(TeamsListViewModel teamsListViewModel, int? divisionId)
        {
            var teams = teamRepository.GetTeamByName(teamsListViewModel.SearchTerm, divisionId);

            return View(new TeamsListViewModel
            {
                Teams = teams,
                Message = message
            });
        }

        public IActionResult Details(int teamId)
        {
            var team = teamRepository.GetTeamById(teamId);
                
            return View(team);
        }
    }
}

