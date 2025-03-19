using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BrotherService : IService<BrotherDto> 
    {
        private readonly IRepository<Brother> _repository;
        private readonly IRepository<Candidate> _repositoryCandidate;
        private readonly IMapper _mapper;
        public BrotherService(IRepository<Brother> repository, IMapper mapper, IRepository<Candidate> repositoryCandidate)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryCandidate = repositoryCandidate;
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

        public BrotherDto[] GetFemaleCandidtes()
        {
            throw new NotImplementedException();
        }

        public BrotherDto[] GetMaleCandidtes()
        {
            throw new NotImplementedException();
        }

        //public List<BrotherDto> GetAllBrothers()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var candidate = _repositoryCandidate.Get((int)userId);
        //    if (candidate == null)
        //    {
        //        return null;
        //    }
        //    var brothers = candidate.Brothers.ToList();
        //    if (brothers == null || !brothers.Any())
        //    {
        //        return new List<BrotherDto>(); // Returning an empty list instead of null is often preferred
        //    }

        //    // Map the list of Brother entities to a list of BrotherDto objects using AutoMapper (or manual mapping)
        //    var brothersDto = _mapper.Map<List<BrotherDto>>(brothers);

        //    // Return the list of BrotherDto objects
        //    return brothersDto;
        //}

        public BrotherDto Update(int id, BrotherDto item)
        {
            return _mapper.Map<BrotherDto>(_repository.UpdateItem(id, _mapper.Map<Brother>(item)));
        }
        

        
    }
}
