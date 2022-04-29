using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface IPlayerRepository
	{
		IEnumerable<Player> Players { get; }

		Team GetPlayersById(int teamId);

		void CreatePlayer(Player player);
	}
}

