using System;
using System.Collections.Generic;
using EPL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EPL.ViewModels
{
	public class PlayersListViewModel
	{
		public IEnumerable<Player> Players { get; set; }

		public string SearchTerm { get; set; }

		public string Message { get; set; }
	}
}

