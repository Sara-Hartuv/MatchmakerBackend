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
    public class BrotherController : ControllerBase
    {

        private readonly IService<BrotherDto> _brotherService;
        private readonly IMyDetails<BrotherDto> _brotherMyDetails;
        public BrotherController(IService<BrotherDto> brotherService, IMyDetails<BrotherDto> brotherMyDetails)
        {
            _brotherService = brotherService;
            _brotherMyDetails = brotherMyDetails;
        }
        // GET: api/<BrotherController>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public List<BrotherDto> Get()
        {
            return _brotherService.GetAll();
        }

        // GET api/<BrotherController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public BrotherDto Get(int id)
        {
            return _brotherService.GetById(id);
        }

        // GET api/<BrotherController>/5
        [HttpGet("GetBrothers")]
        [Authorize(Roles = "admin,candidate")]
        public List<BrotherDto> GetBrothers()
        {
            return _brotherMyDetails.GetMyDetails();
        }

        // POST api/<BrotherController>
        [HttpPost]
        [Authorize(Roles = "candidate")]
        public void Post([FromBody] BrotherDto value)
        {
            _brotherService.AddItem(value);
        }

        // PUT api/<BrotherController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "candidate")]
        public void Put(int id, [FromBody] BrotherDto value)
        {
            _brotherService.Update(id, value);
        }

        // DELETE api/<BrotherController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "candidate")]
        public void Delete(int id)
        {
            _brotherService.Delete(id);
        }
    }
}
