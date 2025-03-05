using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class History
    {
      
        public int Id { get; set; }
        public int IdCandidateGirl { get; set; }
        public int IdCandidateGuy { get; set; }
        public int IdMatchmaker { get; set; }
        public bool IsEngaged{ get; set; }
        public DateTime DateMatch { get; set; }
        public bool Status { get; set; }
        [ForeignKey("IdCandidateGirl")]
        public Candidate girl { get; set; }
        [ForeignKey("IdCandidateGuy")]
        public Candidate guy { get; set; }
        [ForeignKey("IdMatchmaker")]
        public Matchmaker matchmaker { get;set; }

    }
}
