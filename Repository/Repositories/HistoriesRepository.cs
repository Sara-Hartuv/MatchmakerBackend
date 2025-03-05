using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class HistoriesRepository : IRepository<History>
    {
        private readonly IContext context;
        public HistoriesRepository(IContext context)
        {
            this.context = context;
        }
        public History AddItem(History item)
        {
            context.Histories.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Histories.Remove(Get(id));
            context.Save();
        }

        public History Get(int id)
        {
            return context.Histories.FirstOrDefault(x => x.Id == id);
        }

        public List<History> GetAll()
        {
            return context.Histories.ToList();
        }

        public History UpdateItem(int id, History item)
        {
            throw new NotImplementedException();
        }
    }
}
