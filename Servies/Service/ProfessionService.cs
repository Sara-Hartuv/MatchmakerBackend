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
    public class ProfessionService : IService<Profession>
    {
        private readonly IRepository<Profession> _repository;

        public ProfessionService(IRepository<Profession> repository)
        {
            _repository = repository;
        }

        public Profession AddItem(Profession item)
        {
            return _repository.AddItem(item);
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<Profession> GetAll()
        {
           return _repository.GetAll();
        }

        public Profession GetById(int id)
        {
            return _repository.Get(id);
        }

        public Profession Update(int id, Profession item)
        {
            return _repository.UpdateItem(id, item);
        }
    }
}
