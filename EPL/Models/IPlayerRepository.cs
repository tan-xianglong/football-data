using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface IPlayerRepository
	{
		IEnumerable<Player> GetPlayerByName(string name);

		Player GetPlayersById(int playerId);

		Player Update(Player updatedPlayer);
		Player Add(Player newPlayer);
		Player Delete(int id);
	}
}

