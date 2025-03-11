using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IService<Profession> _professionService;
        public ProfessionController(IService<Profession> professionService)
        {
            _professionService = professionService;
        }
        // GET: api/<ProfessionController>
        [HttpGet]
        [Authorize(Roles = "admin,candidate")]
        public List<Profession> Get()
        {
            return _professionService.GetAll();
        }

        // GET api/<ProfessionController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public Profession Get(int id)
        {
            return _professionService.GetById(id);
        }

        // POST api/<ProfessionController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Post([FromBody] Profession value)
        {
            _professionService.AddItem(value);
        }

        // PUT api/<ProfessionController>/5
        //[HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        //public void Put(int id, [FromBody] Profession value)
        //{
        //    _professionService.Update(id, value);
        //}

        // DELETE api/<ProfessionController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            _professionService.Delete(id);
        }
    }
}
