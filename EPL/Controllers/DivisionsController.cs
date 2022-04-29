using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPL.Models;
using EPL.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPL.Controllers
{
    public class DivisionsController : Controller
    {
        private readonly IDivisionRepository divisionRepository;

        public DivisionsController(IDivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult List(DivisionsListViewModel divisionsListViewModel)
        {
            var divisions = divisionRepository.GetDivisionByName(divisionsListViewModel.SearchTerm);

            return View(new DivisionsListViewModel
            {
                Divisions = divisions
            });
        }
    }
}

