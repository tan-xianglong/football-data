using System;
using System.Collections.Generic;
using EPL.Models;

namespace EPL.ViewModels
{
	public class TeamsEditViewModel
	{
        public Team Team { get; set; }

        public string Header { get; set; }

        public IEnumerable<Division> Divisions { get; set; }
    }
}

