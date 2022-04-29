using System;
using System.Collections.Generic;
using EPL.Models;

namespace EPL.ViewModels
{
	public class DivisionsListViewModel
	{
        public IEnumerable<Division> Divisions { get; set; }

        public string SearchTerm { get; set; }
    }
}

