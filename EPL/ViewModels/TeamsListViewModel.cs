using System;
using System.Collections.Generic;
using EPL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EPL.ViewModels
{
	public class TeamsListViewModel
	{
		public IEnumerable<Team> Teams { get; set; }

		public string SearchTerm { get; set; }

		public string Message { get; set; }
	}
}

