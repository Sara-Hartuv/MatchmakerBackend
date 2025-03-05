using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class InquiriesService : IService <Inquiries>
    {
        private readonly IRepository<Inquiries> _repository;
        public InquiriesService(IRepository<Inquiries> repository)
        {
            _repository = repository;
        }

        public Inquiries AddItem(Inquiries item)
        {
            return _repository.AddItem(item);
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<Inquiries> GetAll()
        {
            return _repository.GetAll();
        }

        public Inquiries GetById(int id)
        {
            return _repository.Get(id); 
        }

        public Inquiries Update(int id, Inquiries item)
        {
            return _repository.UpdateItem(id, item);
        }
    }
}
