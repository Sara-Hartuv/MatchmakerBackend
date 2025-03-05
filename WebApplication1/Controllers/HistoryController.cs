using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dtos;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IService<HistoryDto> _historyService;
        public HistoryController(IService<HistoryDto> historyService)
        {
            _historyService = historyService;
        }
        // GET: api/<HistoryController>
        [HttpGet]
        public List<HistoryDto> Get()
        {
            return _historyService.GetAll();
        }

        // GET api/<HistoryController>/5
        [HttpGet("{id}")]
        public HistoryDto Get(int id)
        {
            return _historyService.GetById(id);
        }
      
        // POST api/<HistoryController>
        [HttpPost]
        public void Post([FromForm] HistoryDto value)
        {
            _historyService.AddItem(value);

        }

        // PUT api/<HistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] HistoryDto value)
        {
            _historyService.Update(id, value);
        }

        // DELETE api/<HistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _historyService.Delete(id); 
        }
    }
}
