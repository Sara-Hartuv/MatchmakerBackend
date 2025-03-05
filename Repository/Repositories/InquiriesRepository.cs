using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class InquiriesRepository : IRepository<Inquiries>
    {
        private readonly IContext context;
        public InquiriesRepository(IContext context)
        {
            this.context = context;
        }
        public Inquiries AddItem(Inquiries item)
        {
            context.Inquiries.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Inquiries.Remove(Get(id));
            context.Save();
        }

        public Inquiries Get(int id)
        {
            return context.Inquiries.FirstOrDefault(x => x.Id == id);
        }

        public List<Inquiries> GetAll()
        {
            return context.Inquiries.ToList();
        }

        public Inquiries UpdateItem(int id, Inquiries item)
        {
            throw new NotImplementedException();
        }
    }
}
