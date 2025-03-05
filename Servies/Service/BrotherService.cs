using AutoMapper;
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
    public class BrotherService : IService<BrotherDto>
    {
        private readonly IRepository<Brother> _repository;
        private readonly IMapper _mapper;
        public BrotherService(IRepository<Brother> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public BrotherDto AddItem(BrotherDto item)
        {
            return _mapper.Map<BrotherDto>(_repository.AddItem(_mapper.Map<Brother>(item)));
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<BrotherDto> GetAll()
        {
            return _mapper.Map<List<BrotherDto>>(_repository.GetAll());
        }

        public BrotherDto GetById(int id)
        {
            return _mapper.Map<BrotherDto>(_repository.Get(id));
        }

        public BrotherDto Update(int id, BrotherDto item)
        {
            return _mapper.Map<BrotherDto>(_repository.UpdateItem(id, _mapper.Map<Brother>(item)));
        }
    }
}
