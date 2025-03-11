using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMatching
    {
        public List<(Candidate, Candidate, double)> GetBestMatches();
        public double CalculateMatchScore(Candidate c1, Candidate c2);
    }
}
