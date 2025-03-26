using Repository.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IServiceMatch
    {
        MatchDto GetMatchByIdCandidates(int id1, int id2);
<<<<<<< HEAD
        public List<MatchDto> GetMatchesByIdMatchmaker(int id);
=======
        List<MatchDto> GetAllMatchByIdCandidate(int id);
>>>>>>> 1accda3dc4112ab01870d5da64db3688df104076
        List<Matchmaker> GetAllMatchmakerActives();
    }
}
