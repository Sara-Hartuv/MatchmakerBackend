using AutoMapper;
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
    public class CityService : IService<City>
    {
        private readonly IRepository<City> _repository;

        public CityService(IRepository<City> repository)
        {
            _repository = repository;
        }

        public City AddItem(City item)
        {
            return _repository.AddItem(item);
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<City> GetAll()
        {
            return _repository.GetAll();
        }

        public City GetById(int id)
        {
            return _repository.Get(id);
        }

        public City Update(int id, City item)
        {
            return null;
        }
    }
}
