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
    public class InquiriesController : ControllerBase
    {
        private readonly IService<InquiriesDto> _inquiriesService;
        public InquiriesController(IService<InquiriesDto> inquiriesService)
        {
            _inquiriesService = inquiriesService;
        }
        // GET: api/<InquiriesController>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public List<InquiriesDto> Get()
        {
            return _inquiriesService.GetAll();
        }

        // GET api/<InquiriesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public InquiriesDto Get(int id)
        {
            return _inquiriesService.GetById(id);
        }

        // POST api/<InquiriesController>
        [HttpPost]
        [Authorize(Roles = "candidate")]
        public void Post([FromBody] InquiriesDto value)
        {
            _inquiriesService.AddItem(value);
        }

        // PUT api/<InquiriesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "candidate")]
        public void Put(int id, [FromBody] InquiriesDto value)
        {
            _inquiriesService.Update(id, value);
        }

        // DELETE api/<InquiriesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,candidate")]
        public void Delete(int id)
        {
            _inquiriesService.Delete(id);
        }
    }
}
