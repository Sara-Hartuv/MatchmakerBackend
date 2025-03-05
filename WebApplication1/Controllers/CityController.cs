using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CityController : ControllerBase
    {
        private readonly IService<City> _cityService;
        public CityController(IService<City> cityService)
        {
            _cityService = cityService;
        }
        // GET: api/<CityController>
        [HttpGet]
        public List<City> Get()
        {
            return _cityService.GetAll() ;
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public City Get(int id)
        {
            return _cityService.GetById(id);
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] City value)
        {
            _cityService.AddItem(value);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City value)
        {
           _cityService.Update(id, value);
            
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cityService.Delete(id);
        }
    }
}
