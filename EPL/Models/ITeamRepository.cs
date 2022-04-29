﻿using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface ITeamRepository
	{
		IEnumerable<Team> GetTeamByName(string name);

		Team GetTeamById(int teamId);

		Team Update(Team updatedTeam);
		Team Add(Team newTeam);
		Team Delete(int id);
	}
}

