using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface ITeamRepository
	{
		IEnumerable<Team> GetTeamsByName(string name, int? divisionId);

		Team GetTeamById(int teamId);

		Team Update(Team updatedTeam);
		Team Add(Team newTeam);
		Team Delete(int id);
		int Commit();
	}
}

