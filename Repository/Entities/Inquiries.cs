using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
 public  enum Type
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
        public Type Type { get; set; }
    }
}
