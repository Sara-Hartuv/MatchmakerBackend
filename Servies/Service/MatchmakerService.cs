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
    public class MatchmakerService :  IService<MatchmakerDto>, IToAdmin<MatchmakerDto>
    {
        private readonly IRepository<Matchmaker> _repository;
        private readonly IMapper _mapper;
        public MatchmakerService(IRepository<Matchmaker> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public MatchmakerDto AddItem(MatchmakerDto item)
        {
            return _mapper.Map<MatchmakerDto>(_repository.AddItem(_mapper.Map<Matchmaker>(item)));
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<MatchmakerDto> GetAll()
        {
            return _mapper.Map<List<MatchmakerDto>>(_repository.GetAll());
        }

        public MatchmakerDto GetById(int id)
        {
            return _mapper.Map<MatchmakerDto>(_repository.Get(id));
        }
        public List<MatchmakerDto> GetUnConfirmationUsers()
        {
            return _mapper.Map<List<MatchmakerDto>>(_repository.GetAll().Where(c => !c.Confirmation).ToList());
        }
        public List<MatchmakerDto> GetConfirmationUsers()
        {
            return _mapper.Map<List<MatchmakerDto>>(_repository.GetAll().Where(c => c.Confirmation).ToList());
        }
        public void ConfirmationUser(int id)
        {
            Matchmaker c = _repository.Get(id);
            c.Confirmation = true;
            _repository.UpdateItem(id, c);
        }
        public MatchmakerDto Update(int id, MatchmakerDto item)
        {
            return _mapper.Map<MatchmakerDto>(_repository.UpdateItem(id, _mapper.Map<Matchmaker>(item)));
        }
    }
}
