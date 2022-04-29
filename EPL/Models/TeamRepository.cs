using System;
using System.Linq;
using System.Collections.Generic;

namespace EPL.Models
{
	public class TeamRepository : ITeamRepository
	{
        private readonly AppDbContext appDbContext;

        public TeamRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
        }

        public Team Add(Team newTeam)
        {
            throw new NotImplementedException();
        }

        public Team Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Team GetTeamById(int teamId)
        {
            return appDbContext.Teams.Find(teamId);
        }

        public IEnumerable<Team> GetTeamByName(string name)
        {
            var query = from d in appDbContext.Teams
                        where d.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby d.Name
                        select d;
            return query;
        }

        public Team Update(Team updatedTeam)
        {
            throw new NotImplementedException();
        }
    }
}

