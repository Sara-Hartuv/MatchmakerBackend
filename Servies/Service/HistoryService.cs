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
    public class HistoryService : IService<History>
    {
        private readonly IRepository<History> _repository;

        public HistoryService(IRepository<History> repository)
        {
            _repository = repository;
        }
        public History AddItem(History item)
        {
            return _repository.AddItem(item);
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id); 
        }

        public List<History> GetAll()
        {
            return _repository.GetAll();
        }

        public History GetById(int id)
        {
            return _repository.Get(id);
        }

        public History Update(int id, History item)
        {
            return _repository.UpdateItem(id, item);
        }
    }
}
