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
    public class HistoryController : ControllerBase
    {
        private readonly IService<HistoryDto> _historyService;
        public HistoryController(IService<HistoryDto> historyService)
        {
            _historyService = historyService;
        }
        // GET: api/<HistoryController>
        [HttpGet]
        [Authorize(Roles = "admin,matchmaker")]
        public List<HistoryDto> Get()
        {
            return _historyService.GetAll();
        }

        // GET api/<HistoryController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,matchmaker")]
        public HistoryDto Get(int id)
        {
            return _historyService.GetById(id);
        }
      
        // POST api/<HistoryController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Post([FromBody] HistoryDto value)
        {
            _historyService.AddItem(value);

        }
        [Authorize(Roles = "admin,matchmaker")]
        //לבדוק את העניין שאסור ששדכן יוכל לשנות סתם דברים אולי צריך להוסיף כאן עוד פונקציה שמשנה רק משהו ספציפי ואת הפעולה של עדכון ההיסטוריה להרשות רק למנהל
        // PUT api/<HistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] HistoryDto value)
        {
            _historyService.Update(id, value);
        }

        // DELETE api/<HistoryController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            _historyService.Delete(id); 
        }
    }
}
