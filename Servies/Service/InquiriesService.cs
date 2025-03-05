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
    public class InquiriesService : IService <InquiriesDto>
    {
        private readonly IRepository<Inquiries> _repository;
        private readonly IMapper _mapper;
        public InquiriesService(IRepository<Inquiries> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public InquiriesDto AddItem(InquiriesDto item)
        {
            return _mapper.Map<InquiriesDto>(_repository.AddItem(_mapper.Map<Inquiries>(item)));
        }

        public void Delete(int id)
        {
           _repository.DeleteItem(id);
        }

        public List<InquiriesDto> GetAll()
        {
            return _mapper.Map<List<InquiriesDto>>(_repository.GetAll());
        }

        public InquiriesDto GetById(int id)
        {
            return _mapper.Map<InquiriesDto>(_repository.Get(id));
        }

        public InquiriesDto Update(int id, InquiriesDto item)
        {
            return _mapper.Map<InquiriesDto>(_repository.UpdateItem(id, _mapper.Map<Inquiries>(item)));
        }
    }
}
