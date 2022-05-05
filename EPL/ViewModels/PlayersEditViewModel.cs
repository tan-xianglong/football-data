using System;
using System.Collections.Generic;
using EPL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EPL.ViewModels
{
	public class PlayersEditViewModel
	{
        public Player Player { get; set; }

        public string Header { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        public IEnumerable<SelectListItem> Positions { get; set; }
    }
}

