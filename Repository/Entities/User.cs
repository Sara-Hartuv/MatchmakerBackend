using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
   public enum Gender
    {
        גבר,
        אישה
    }
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public string? NumId { get; set; } 
        public DateTime? BornDate { get; set; } 
        public string? Phone { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; }//עיר
        public string? Adress { get; set; }

        public static object FindFirstValue(string nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
