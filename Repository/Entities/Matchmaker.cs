using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Matchmaker:User
    {

        //public int Id { get; set; }
        public int? ExperienceYear { get; set; }
        public List<Match>? History { get; set; }
        public int Score { get; set; } = 0;
    }
}
