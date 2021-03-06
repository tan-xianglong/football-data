using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPL.Models;
using EPL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPL.Controllers
{
    public class DivisionsController : Controller
    {

        private readonly IDivisionRepository divisionRepository;

        [TempData]
        public string message { get; set; }

        public DivisionsController(IDivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }
        // GET: /<controller>/

        public IActionResult List(DivisionsListViewModel divisionsListViewModel)
        {
            var divisions = divisionRepository.GetDivisionByName(divisionsListViewModel.SearchTerm);

            return View(new DivisionsListViewModel
            {
                Divisions = divisions,
                Message = message
            });
        }

        [Authorize]
        public IActionResult Edit(int? divisionId)
        {
            Division division;
            string header;
            if(!divisionId.HasValue)
            {
                division = new Division();
                header = "Add New";
            }
            else
            {
                division = divisionRepository.GetDivisionById(divisionId.Value);
                header = "Edit";
            }
            if (division == null)
            {
                return NotFound();
            }
            return View(new DivisionsEditViewModel
            {
                Division = division,
                Header = header
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Division division)
        {
            if(division.DivisionId > 0)
            {
                divisionRepository.Update(division);
            }
            else
            {
                divisionRepository.Add(division);
            }
            divisionRepository.Commit();
            TempData["message"] = "Division saved!"; //am I doing the tempdata right by putting at controller? if not, where?
            return RedirectToAction("List");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int divisionId)
        {
            //to add existing team check in the future
            var division = divisionRepository.Delete(divisionId);
            divisionRepository.Commit();
            if(division == null)
            {
                return NotFound();
            }

            TempData["Message"] = $"{division.Name} deleted.";
            return RedirectToAction("List");

        }
    }
}

