using System;
using System.Linq;
using System.Collections.Generic;

namespace EPL.Models
{
	public class DivisionRepository : IDivisionRepository
	{
        private readonly AppDbContext appDbContext;

        public DivisionRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
        }

        public Division Add(Division newDivision)
        {
            throw new NotImplementedException();
        }

        public Division Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Division GetDivisionById(int divisionId)
        {
            return appDbContext.Divisions.Find(divisionId);
        }

        public IEnumerable<Division> GetDivisionByName(string name)
        {
            var query = from d in appDbContext.Divisions
                        where d.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby d.Name
                        select d;
            return query;
        }

        public Division Update(Division updatedDivision)
        {
            throw new NotImplementedException();
        }
    }
}

