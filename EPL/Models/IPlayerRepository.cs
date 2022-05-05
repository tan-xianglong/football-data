using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface IPlayerRepository
	{
		IEnumerable<Player> GetPlayersByName(string name);

		Player GetPlayerById(int playerId);

		Player Update(Player updatedPlayer);
		Player Add(Player newPlayer);
		Player Delete(int id);
		int Commit();
	}
}

