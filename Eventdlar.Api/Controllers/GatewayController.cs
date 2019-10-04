using System;
using System.Threading.Tasks;
using Eventdlar.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RawRabbit;

namespace Eventdlar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IBusClient _client;
        public GatewayController(IBusClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            await _client.PublishAsync(new CreateEvent("test", "udalo sie"), default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Commands")).WithRoutingKey("createevent.#"));
            return "dziala";
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateEvent command)
        {
            Console.WriteLine($"{command.Name} {command.Description}");
            await _client.PublishAsync(command, default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Commands")).WithRoutingKey("createevent.#"));
            return Created("Task",null);
        }  
    }
}
