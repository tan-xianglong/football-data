using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface IDivisionRepository
	{
		IEnumerable<Division> Divisions { get; }

		Division GetDivisionById(int divisionId);

		void CreateDivision(Division division);
	}
}

