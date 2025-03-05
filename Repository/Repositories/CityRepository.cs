using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly IContext context;

        public CityRepository(IContext context)
        {
            this.context = context;
        }
        public City AddItem(City item)
        {
            context.Cities.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Cities.Remove(Get(id));
            context.Save();
        }

        public City Get(int id)
        {
            return context.Cities.FirstOrDefault(x => x.Id == id);
        }

        public List<City> GetAll()
        {
            return context.Cities.ToList();
        }

        public City UpdateItem(int id, City item)
        {
            throw new NotImplementedException();
        }
    }
}
