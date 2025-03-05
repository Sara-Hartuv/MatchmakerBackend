using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CandidateService:IService<CandidateDto>
    {
        private readonly IRepository<Candidate> _repository;
        private readonly IMapper _mapper;

         public CandidateService(IRepository<Candidate> repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

   
        public CandidateDto AddItem(CandidateDto item)
        {
            return _mapper.Map<CandidateDto>(_repository.AddItem(_mapper.Map<Candidate>(item)));
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

       
        public List<CandidateDto> GetAll()
        {
            return _mapper.Map<List<CandidateDto>>(_repository.GetAll());
        }


        public CandidateDto GetById(int id)
        {
            return _mapper.Map<CandidateDto>(_repository.Get(id));
        }

        public CandidateDto Update(int id, CandidateDto item)
        {
            return _mapper.Map<CandidateDto>(_repository.UpdateItem(id, _mapper.Map<Candidate>(item)));
        }
    
    }
}
