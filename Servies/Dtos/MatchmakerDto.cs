using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos
{
    public class MatchmakerDto
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string NumId { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; } // ✔ מזהה העיר בלבד
        public string Adress { get; set; }
        public int ExperienceYear { get; set; }
    }
}
