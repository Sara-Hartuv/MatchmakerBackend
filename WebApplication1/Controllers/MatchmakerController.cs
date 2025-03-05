using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dtos;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchmakerController : ControllerBase
    {
        private readonly IService<MatchmakerDto> _matchmakerService;
        public MatchmakerController(IService<MatchmakerDto> matchmakerService)
        {
            _matchmakerService = matchmakerService;
        }
        // GET: api/<MatchmakerController>
        [HttpGet]
        public List<MatchmakerDto> Get()
        {
            return _matchmakerService.GetAll();
        }

        // GET api/<MatchmakerController>/5
        [HttpGet("{id}")]
        public MatchmakerDto Get(int id)
        {
            return _matchmakerService.GetById(id);
        }

        // POST api/<MatchmakerController>
        [HttpPost]
        public void Post([FromForm] MatchmakerDto value)
        {
            _matchmakerService.AddItem(value);

        }

        // PUT api/<MatchmakerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] MatchmakerDto value)
        {
            _matchmakerService.Update(id, value);
        }

        // DELETE api/<MatchmakerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _matchmakerService.Delete(id);

        }
    }   
}
