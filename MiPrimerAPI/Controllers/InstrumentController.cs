using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiPrimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private static List<string> instruments = new() { "Guitarra", "Batería", "Piano" };

        // GET: api/<InstrumentController>
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(instruments);
        }

        // GET api/<InstrumentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstrumentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InstrumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstrumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
