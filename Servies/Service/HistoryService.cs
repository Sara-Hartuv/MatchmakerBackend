using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class HistoryService : IService<HistoryDto>
    {
        private readonly IRepository<History> _repository;
        private readonly IMapper _mapper;
        public HistoryService(IRepository<History> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper=mapper;

        }
        public HistoryDto AddItem(HistoryDto item)
        {

            return _mapper.Map<HistoryDto>(_repository.AddItem(_mapper.Map<History>(item)));
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id); 
        }

        public List<HistoryDto> GetAll()
        {
            return _mapper.Map<List<HistoryDto>>(_repository.GetAll());
        }

        public HistoryDto GetById(int id)
        {
            return _mapper.Map<HistoryDto>(_repository.Get(id));
        }

        public HistoryDto Update(int id, HistoryDto item)
        {
            return _mapper.Map<HistoryDto>(_repository.UpdateItem(id, _mapper.Map<History>(item)));
        }
        public List<HistoryDto> GetAllEngagedment()
        {
            return GetAll().Where(x => x.IsEngaged == true).ToList();
        }
    }
}
