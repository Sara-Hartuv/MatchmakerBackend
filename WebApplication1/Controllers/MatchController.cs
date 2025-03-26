using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dtos;
using Service.Interfaces;
using Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IService<CandidateDto> _candidateService;
        private readonly IService<MatchmakerDto> _matchmakerService;
        private readonly IMyDetails<Candidate> _candidateDetails;
        private readonly IEmailService _emailService;
        private readonly IServiceMatch _serviceMatch;
        private readonly IService<MatchDto> _MatchDtoService;
        private readonly IMapper _mapper;
        
        public MatchController(IService<MatchDto> matchDtoService, IService<CandidateDto> candidateService, IService<MatchmakerDto> matchmakerService, IEmailService emailService, IMapper mapper, IServiceMatch serviceMatch, IMyDetails<Candidate> candidateDetails)
        {
            _MatchDtoService = matchDtoService;
            _candidateService = candidateService;
            _matchmakerService = matchmakerService;
            _serviceMatch = serviceMatch;
            _emailService = emailService;
            _mapper = mapper;
            _candidateDetails = candidateDetails;
        }
        // GET: api/<HistoryController>
        [HttpGet]
        [Authorize(Roles = "admin,matchmaker")]
        public List<MatchDto> Get()
        {
            return _MatchDtoService.GetAll();
        }

        // GET api/<HistoryController>/5
        [HttpGet("GetAllMatchById{id}")]
        //[Authorize(Roles = "admin,matchmaker")]
        public List<string> GetAllMatchById(int id)
        {
            List<MatchDto> mList = _serviceMatch.GetAllMatchByIdCandidate(id);
            List<string> sList = new List<string>();

            foreach (MatchDto match in mList)
            {
                string candidateDetails;
                var candidate = _candidateService.GetById(id);
                if (match.ConfirmationGirl && match.ConfirmationGuy)
                {
                     candidateDetails = _candidateDetails.GetAllCandidateInfo(_mapper.Map<Candidate>(candidate));
                    sList.Add(candidateDetails);
                }
                else
                {
                    candidateDetails = _candidateDetails.GetGeneralCandidateInfo(_mapper.Map<Candidate>(candidate));
                    sList.Add(candidateDetails);
                }
            }

            return sList;
        }



        // GET api/<HistoryController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,matchmaker")]
        public MatchDto Get(int id)
        {
            return _MatchDtoService.GetById(id);
        }

        [HttpGet("GetMatchesByIdMatchmaker{id}")]
        [Authorize(Roles = "admin,matchmaker")]
        public List<MatchDto> GetMatchesByIdMatchmaker(int id)
        {
            return _serviceMatch.GetMatchesByIdMatchmaker(id);
        }

        // POST api/<HistoryController>
        [HttpPost]
        //[Authorize(Roles = "admin,matchmaker")]
        public async Task<IActionResult> Post(int idCandudate1, int idCandudate2, int idMatchmaker)
        {
            Match m = new Match();
            m.IdCandidateGuy = idCandudate1;
            m.IdCandidateGirl = idCandudate2;
            m.IdMatchmaker = idMatchmaker;
            m.Status = true;
            _MatchDtoService.AddItem(_mapper.Map<MatchDto>(m));
            await _emailService.SendMatchEmailAsync(idCandudate1, idCandudate2);
            return Ok("Email Sent!");

        }

        

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmMatch([FromQuery] int candidateId, [FromQuery] int matchId)
        {
            Match match;
            Candidate c1 = _mapper.Map<Candidate>( _candidateService.GetById(candidateId));
            if (c1.Gender == Gender.גבר)
            {
                match = _mapper.Map<Match>(_serviceMatch.GetMatchByIdCandidates(candidateId, matchId));
                if (match == null)
                {
                    Console.WriteLine($"Match not found for Candidate: {candidateId}, MatchId: {matchId}");
                    return NotFound("Match not found");
                }
                if (match.ConfirmationGuy)
                {
                    return BadRequest("כבר אישרת את ההתאמה בעבר. לא ניתן לאשר שוב.");
                }
                match.ConfirmationGuy = true;
            }
            else
            {
                match = _mapper.Map<Match>(_serviceMatch.GetMatchByIdCandidates(matchId, candidateId));
                if (match == null)
                    return NotFound("Match not found");
                if (match.ConfirmationGirl)
                {
                    return BadRequest("כבר אישרת את ההתאמה בעבר. לא ניתן לאשר שוב.");
                }
                match.ConfirmationGirl = true;
            }

            _MatchDtoService.Update(match.Id, _mapper.Map<MatchDto>(match));

            // אם שני הצדדים אישרו, שולחים מייל לשדכן
            if (match.ConfirmationGuy && match.ConfirmationGirl)
            {
                Candidate c2 = _mapper.Map<Candidate>(_candidateService.GetById(matchId));
                Matchmaker matchmaker = _mapper.Map<Matchmaker>( _matchmakerService.GetById(match.IdMatchmaker));
                string matchDetails = $"המועמדים אישרו את השידוך!\n הפרטים של המועמדים : \n:1 מועמד  \n{_candidateDetails.GetAllCandidateInfo(c1)+"\n אימייל:" +c1.Email+"\n מס טלפון :"+c1.Phone} \n מועמד 2: \n{_candidateDetails.GetAllCandidateInfo(c2) + "\n אימייל:" + c2.Email + "\n מס טלפון :" + c2.Phone}";

                await _emailService.SendEmailAsync(matchmaker.Email, "שידוך מאושר!", matchDetails);
                await _emailService.SendEmailAsync(c1.Email, "המשך פרטים", _candidateDetails.GetAllCandidateInfo(c2));
                await _emailService.SendEmailAsync(c2.Email, "המשך פרטים", _candidateDetails.GetAllCandidateInfo(c1));
                match.Active = true;
                _MatchDtoService.Update(match.Id, _mapper.Map<MatchDto>(match));
            }

            return Ok("Match confirmed!");
        }

        //[Authorize(Roles = "admin,matchmaker")]
        //לבדוק את העניין שאסור ששדכן יוכל לשנות סתם דברים אולי צריך להוסיף כאן עוד פונקציה שמשנה רק משהו ספציפי ואת הפעולה של עדכון ההיסטוריה להרשות רק למנהל
        // PUT api/<HistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MatchDto value)
        {
            _MatchDtoService.Update(id, value);
        }

        // DELETE api/<HistoryController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            _MatchDtoService.Delete(id);
        }
    }
}
