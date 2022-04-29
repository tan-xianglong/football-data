using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface ITeamRepository
	{
		IEnumerable<Team> Teams { get; }

		Team GetTeamById(int teamId);

		void CreateTeam(Team team);
	}
}

