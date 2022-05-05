using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EPL.Models
{
	public class PlayerRepository : IPlayerRepository
	{
        private readonly AppDbContext appDbContext;

        public PlayerRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
        }

        public Player Add(Player newPlayer)
        {
            appDbContext.Add(newPlayer);
            return newPlayer;
        }

        public Player Delete(int id)
        {
            var player = GetPlayerById(id);
            if (player != null)
            {
                appDbContext.Players.Remove(player);
            }
            return player;
        }

        public IEnumerable<Player> GetPlayersByName(string name)
        {
            var query = from p in appDbContext.Players
                        where p.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby p.Name
                        select p;
            return query;
        }

        public Player GetPlayerById(int playerId)
        {
            var player = appDbContext.Players.FirstOrDefault(p => p.PlayerId == playerId);
            var team = appDbContext.Teams.FirstOrDefault(t => t.TeamId == player.TeamId);

            player.Team = team;

            return player;
        }

        public Player Update(Player updatedPlayer)
        {
            var entity = appDbContext.Players.Attach(updatedPlayer);
            entity.State = EntityState.Modified;
            return updatedPlayer;
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();
        }
    }
}

