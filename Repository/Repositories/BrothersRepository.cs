using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BrothersRepository : IRepository<Brother>
    {
        private readonly IContext context;
        public BrothersRepository(IContext context)
        {
            this.context = context;
        }
        public Brother AddItem(Brother item)
        {
            context.Brothers.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Brothers.Remove(Get(id));
            context.Save();
        }

        public Brother Get(int id)
        {
            return context.Brothers.FirstOrDefault(x => x.Id == id);

        }

        public List<Brother> GetAll()
        {
            return context.Brothers.ToList();
        }

        public Brother UpdateItem(int id, Brother item)
        {
            throw new NotImplementedException();
        }
    }
}
