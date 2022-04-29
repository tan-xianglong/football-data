using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface IPlayerRepository
	{
		IEnumerable<Player> Players { get; }

		Player GetPlayersById(int playerId);

		void CreatePlayer(Player player);
	}
}

