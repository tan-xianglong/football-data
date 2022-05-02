using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            appDbContext.Add(newDivision);
            return newDivision;
        }

        public Division Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Division GetDivisionById(int divisionId)
        {
            return appDbContext.Divisions.FirstOrDefault(d => d.DivisionId == divisionId);
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
            var entity = appDbContext.Divisions.Attach(updatedDivision);
            entity.State = EntityState.Modified;
            return updatedDivision;
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();
        }
    }
}

