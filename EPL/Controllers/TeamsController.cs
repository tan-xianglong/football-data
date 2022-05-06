using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EPL.Models;
using EPL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EPL.Controllers
{
	public class TeamsController : Controller
	{
        private readonly ITeamRepository teamRepository;
        private readonly IDivisionRepository divisionRepository;

        [TempData]
        public string message { get; set; }

        public TeamsController(ITeamRepository teamRepository, IDivisionRepository divisionRepository)
		{
            this.teamRepository = teamRepository;
            this.divisionRepository = divisionRepository;
        }

        public IActionResult List(TeamsListViewModel teamsListViewModel, int? divisionId)
        {
            var teams = teamRepository.GetTeamsByName(teamsListViewModel.SearchTerm, divisionId);

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

        [Authorize]
        public IActionResult Edit(int? teamId)
        {
            Team team;
            string header;
            IEnumerable<Division> divisions = divisionRepository.GetDivisionByName(null);

            if(!teamId.HasValue)
            {
                team = new Team();
                header = "Add New";
            }
            else
            {
                team = teamRepository.GetTeamById(teamId.Value);
                header = "Edit";
            }

            if(team == null)
            {
                return NotFound();
            }
            return View(new TeamsEditViewModel
            {
                Team = team,
                Header = header,
                Divisions = divisions
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Team team)
        {
            if(team.TeamId > 0)
            {
                teamRepository.Update(team);
            }
            else
            {
                teamRepository.Add(team);
            }
            teamRepository.Commit();
            TempData["message"] = "Team saved!";
            return RedirectToAction("List");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int teamId)
        {
            //to add existing player check in the future
            var team = teamRepository.Delete(teamId);
            teamRepository.Commit();
            if(team == null)
            {
                return NotFound();
            }

            TempData["Message"] = $"{team.Name} deleted.";
            return RedirectToAction("List");
        }
    }
}

