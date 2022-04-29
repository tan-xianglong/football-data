using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public class MockPlayerRepository : IPlayerRepository
	{

        public IEnumerable<Player> Players =>
            new List<Player>
            {
                new Player
                {
                    PlayerId = 1,
                    TeamId = 1,
                    Name = "David De Gea",
                    Position = "Goalkeeper",
                    ShirtNumber = 1,
                    Height = 1.92,
                    Weight = 82,
                    YearOfBirth = 1990
                },
                new Player
                {
                    PlayerId = 2,
                    TeamId = 1,
                    Name = "Cristiano Ronaldo",
                    Position = "Striker",
                    ShirtNumber = 7,
                    Height = 1.87,
                    Weight = 85,
                    YearOfBirth = 1985
                }
            };

        public void CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Team GetPlayersById(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}

