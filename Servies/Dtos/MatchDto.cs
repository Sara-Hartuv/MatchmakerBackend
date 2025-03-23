using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int IdCandidateGirl { get; set; }
        public int IdCandidateGuy { get; set; }
        public int IdMatchmaker { get; set; }
        public bool IsEngaged { get; set; }
        public bool ConfirmationGuy { get; set; }
        public bool ConfirmationGirl { get; set; }
        public DateTime DateMatch { get; set; }
        public bool Status { get; set; }
   
    }
}
