using System;
using System.Collections.Generic;
using EPL.Models;

namespace EPL.ViewModels
{
	public class HomeIndexViewModel
	{
		public IEnumerable<Player> Players { get; set; }


		public IEnumerable<Team> Teams { get; set; }

        public IEnumerable<Division> Divisions { get; set; }

        public string SearchTerm { get; set; }

        public HomeIndexViewModel()
        {
            SearchTerm = "Search name";
        }
	}
}

