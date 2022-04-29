using System;
using System.Collections.Generic;
using System.Linq;

namespace EPL.Models
{
    public class MockDivisionRepository : IDivisionRepository
    {
        public IEnumerable<Division> Divisions =>
            new List<Division>
            {
                new Division
                {
                    DivisionId = 1,
                    Name = "English Premier League"
                }
            };

        public void CreateDivision(Division division)
        {
            throw new NotImplementedException();
        }

        public Division GetDivisionById(int divisionId)
        {
            return Divisions.FirstOrDefault(d => d.DivisionId == divisionId);
        }
    }
}

