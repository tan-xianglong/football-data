using System;
using System.Collections.Generic;
using System.Linq;

namespace EPL.Models
{
	public class MockTeamRepository : ITeamRepository
	{

        public IEnumerable<Team> Teams =>
            new List<Team>
            {
                new Team
                {
                    TeamId = 1,
                    DivisionId = 1,
                    Name = "Manchester United",
                    Location = "Manchester",
                    Stadium = "Old Trafford",
                }
            };

        public void CreateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public Team GetTeamById(int teamId)
        {
            return Teams.FirstOrDefault(t => t.TeamId == teamId);
        }
    }
}

