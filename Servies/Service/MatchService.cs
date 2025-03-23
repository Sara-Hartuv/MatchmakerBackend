using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MatchService : IService<MatchDto>, IServiceMatch
    {
        private readonly IRepository<Match> _repository;
        private readonly IRepository<Matchmaker> _repositoryMatchmaker;
        private readonly IMapper _mapper;
        public MatchService(IRepository<Match> repository, IMapper mapper, IRepository<Matchmaker> repositoryMatchmaker)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryMatchmaker = repositoryMatchmaker;
        }
        public MatchDto AddItem(MatchDto item)
        {

            return _mapper.Map<MatchDto>(_repository.AddItem(_mapper.Map<Match>(item)));
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<MatchDto> GetAll()
        {
            return _mapper.Map<List<MatchDto>>(_repository.GetAll());
        }

        public MatchDto GetById(int id)
        {
            return _mapper.Map<MatchDto>(_repository.Get(id));
        }

        public MatchDto GetMatchByIdCandidates(int id1, int id2)
        {
            List<Match> m = _repository.GetAll();
            foreach (Match match in m)
            {
                if (match.IdCandidateGuy == id1 && match.IdCandidateGirl == id2 || match.IdCandidateGuy == id2 && match.IdCandidateGirl == id1)
                {
                    return _mapper.Map<MatchDto>(match);
                }
            }
            return null;
        }


        public MatchDto Update(int id, MatchDto item)
        {
            return _mapper.Map<MatchDto>(_repository.UpdateItem(id, _mapper.Map<Match>(item)));
        }
        public List<MatchDto> GetAllEngagedment()
        {
            return GetAll().Where(x => x.IsEngaged == true).ToList();
        }

        public List<Matchmaker> GetAllMatchmakerActives()
        {
            List<Matchmaker> matchmakers = new List<Matchmaker>();
            List<Match> m = _mapper.Map<List<Match>>(GetAll());
            Matchmaker matchmaker;
            foreach (Match match in m)
            {
                if (match.Active == true)
                {
                    matchmaker = _repositoryMatchmaker.Get(match.IdMatchmaker);
                    if (matchmakers.Find(m => m.Id == matchmaker.Id) == null)
                        matchmakers.Add(matchmaker);
                }
            }
            return matchmakers;
        }

    }
}
