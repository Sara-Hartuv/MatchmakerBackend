using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
 public  enum TypeInquire
        {
            מחותנים,
            שכנים,
            חברים,
            רבנים_מורות
        }
    public class Inquiries
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public TypeInquire Type { get; set; }
        
        //[ForeignKey("CandidateId")]
        //public int CandidateId { get; set; }
        //public Candidate Candidate { get; set; }
    }
}
