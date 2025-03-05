using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProfessionsRepository : IRepository<Profession>
    {
        private readonly IContext context;
        public ProfessionsRepository(IContext context)
        {
            this.context = context;
        }
        public Profession AddItem(Profession item)
        {
            context.Professions.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Professions.Remove(Get(id));
            context.Save();
        }

        public Profession Get(int id)
        {
            return context.Professions.FirstOrDefault(x => x.Id == id);
        }

        public List<Profession> GetAll()
        {
            return context.Professions.ToList();
        }

        public Profession UpdateItem(int id, Profession item)
        {
            throw new NotImplementedException();
        }
    }
}
