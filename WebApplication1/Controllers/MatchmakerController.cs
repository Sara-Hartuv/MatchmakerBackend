using Microsoft.AspNetCore.Authorization;
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
        private readonly IToAdmin<MatchmakerDto> _matchmakerToAdmin;
        public MatchmakerController(IService<MatchmakerDto> matchmakerService, IToAdmin<MatchmakerDto> matchmakerToAdmin)
        {
            _matchmakerService = matchmakerService;
            _matchmakerToAdmin = matchmakerToAdmin;
        }
        // GET: api/<MatchmakerController>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public List<MatchmakerDto> Get()
        {
            return _matchmakerService.GetAll();
        }

        // GET api/<MatchmakerController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public MatchmakerDto Get(int id)
        {
            return _matchmakerService.GetById(id);
        }

        // PUT api/<MatchmakerController>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin,matchmaker")]
        public void Put(int id, [FromBody] MatchmakerDto value)
        {
            _matchmakerService.Update(id, value);
        }

        // DELETE api/<MatchmakerController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            _matchmakerService.Delete(id);

        }

        [HttpGet("GetUnConfirmationMatchmakers")]
        //[Authorize(Roles = "admin")]
        public List<MatchmakerDto> GetUnConfirmationMatchmakers()
        {
            return _matchmakerToAdmin.GetUnConfirmationUsers();
        }
        [HttpGet("GetConfirmationMatchmakers")]
        //[Authorize(Roles = "admin")]
        public List<MatchmakerDto> GetConfirmationMatchmakers()
        {
            return _matchmakerToAdmin.GetConfirmationUsers();
        }

        [HttpPut("Confirmation{id}")]
        //[Authorize(Roles = "admin")]
        public void ConfirmationMatchmaker(int id)
        {
            _matchmakerToAdmin.ConfirmationUser(id);
        }
    }
}
