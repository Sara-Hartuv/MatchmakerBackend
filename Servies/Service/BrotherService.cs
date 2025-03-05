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
    public class BrotherService : IService<Brother>
    {
        private readonly IRepository<Brother> _repository;
        public BrotherService(IRepository<Brother> repository)
        {
            _repository = repository;
        }

        public Brother AddItem(Brother item)
        {
            return _repository.AddItem(item);
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<Brother> GetAll()
        {
            return _repository.GetAll();
        }

        public Brother GetById(int id)
        {
            return _repository.Get(id);
        }

        public Brother Update(int id, Brother item)
        {
            return _repository.UpdateItem(id, item);
        }
    }
}
