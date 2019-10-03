using System;
using System.Threading.Tasks;
using Eventdlar.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Eventdlar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBusClient _client;
        public ValuesController(IBusClient client)
        {
            _client = client;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            await _client.PublishAsync(new CreateEvent("test", "udalo sie"), default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Commands")).WithRoutingKey("createevent.#"));
            return "dziala";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
