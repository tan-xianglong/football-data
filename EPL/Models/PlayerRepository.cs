using System;
using System.Linq;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public Player Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetPlayerByName(string name)
        {
            var query = from d in appDbContext.Players
                        where d.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby d.Name
                        select d;
            return query;
        }

        public Player GetPlayersById(int playerId)
        {
            return appDbContext.Players.Find(playerId);
        }

        public Player Update(Player updatedPlayer)
        {
            throw new NotImplementedException();
        }
    }
}

