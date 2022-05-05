using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            appDbContext.Add(newTeam);
            return newTeam;
        }

        public Team Delete(int id)
        {
            var team = GetTeamById(id);
            if (team != null)
            {
                appDbContext.Teams.Remove(team);
            }
            return team;
        }

        public Team GetTeamById(int teamId)
        {
            var team = appDbContext.Teams.FirstOrDefault(t => t.TeamId == teamId);
            var players = appDbContext.Players.Where(p => p.TeamId == teamId)
                .OrderBy(p => p.ShirtNumber).ToList();
            var division = appDbContext.Divisions.FirstOrDefault(d => d.DivisionId == team.DivisionId);

            team.Players = players;
            team.Division = division;
            return team;
        }

        public IEnumerable<Team> GetTeamsByName(string name, int? divisionId)
        {
            IEnumerable<Team> query;
            if (divisionId.HasValue)
            {
                query = from t in appDbContext.Teams
                        where t.DivisionId.Equals(divisionId)
                        orderby t.Name
                        select t;
            }
            else
            {
                query = from t in appDbContext.Teams
                        where t.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby t.Name
                        select t;
            }
            return query;
        }

        public Team Update(Team updatedTeam)
        {
            var entity = appDbContext.Teams.Attach(updatedTeam);
            entity.State = EntityState.Modified;
            return updatedTeam;
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();
        }
    }
}

