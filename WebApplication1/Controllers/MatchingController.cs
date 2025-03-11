using Microsoft.AspNetCore.Mvc;
using Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchingController : ControllerBase
    {

        private readonly MatchingService _matchingService;

        public MatchingController(MatchingService matchingService)
        {
            _matchingService = matchingService;
        }
        // GET: api/<MachingController>
        [HttpGet]
        public IActionResult GetBestMatches()
        {
            var matches = _matchingService.GetBestMatches();
            return Ok(matches);
        }

        // GET api/<MachingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MachingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MachingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MachingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
