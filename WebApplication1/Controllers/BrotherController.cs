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
        public BrotherController(IService<BrotherDto> brotherService)
        {
            _brotherService = brotherService;
        }
        //// GET: api/<BrotherController>
        //[HttpGet]
        //public List<Brother> Get()
        //{
        //    return _brotherService.GetAll();
        //}

        // GET api/<BrotherController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "candidate")]
        public BrotherDto Get(int id)
        {
            return _brotherService.GetById(id);
        }

        // POST api/<BrotherController>
        [HttpPost]
        [Authorize(Roles = "candidate")]
        public void Post([FromForm] BrotherDto value)
        {
            _brotherService.AddItem(value);
        }

        // PUT api/<BrotherController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "candidate")]
        public void Put(int id, [FromForm] BrotherDto value)
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
