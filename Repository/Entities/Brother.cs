using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{

    
    public class Brother
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceOfStudy { get; set; }
        public Gender Gender { get; set; }
        public bool Married { get; set; }
        public string NameIn_laws { get; set; }
        public string AddressIn_laws { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
