using System;
using System.Collections.Generic;

namespace EPL.Models
{
	public interface IDivisionRepository
	{
		Division GetDivisionById(int divisionId);

		IEnumerable<Division> GetDivisionByName(string name);

		Division Update(Division updatedDivision);
		Division Add(Division newDivision);
		Division Delete(int id);

	}
}

