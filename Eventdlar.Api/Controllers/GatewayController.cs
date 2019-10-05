using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventdlar.Common.Commands;
using Eventdlar.Common.Queries;
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

        [HttpGet("events")]
        public async Task<ActionResult<Events>> GetEvents()
        {
            var response = await _client.RequestAsync<GetEvents,Events>(new GetEvents(),default(Guid),
            cfg => cfg.WithExchange(ex => ex.WithName("Queries")).WithRoutingKey("getevents.#").WithReplyQueue(q => q.WithName(nameof(GetEvents))));
            return response;
        }

        [HttpGet("notifications")]
        public async Task<ActionResult<Notifications>> GetNotification()
        {
            var response = await _client.RequestAsync<GetNotifications,Notifications>(new GetNotifications(),default(Guid),
            cfg => cfg.WithExchange(ex => ex.WithName("Queries")).WithRoutingKey("getnotifications.#").WithReplyQueue(q => q.WithName(nameof(GetNotifications))));
            return response;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody]CreateEvent command)
        {
            Console.WriteLine($"{command.Name} {command.Description}");
            await _client.PublishAsync(command, default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Commands")).WithRoutingKey("createevent.#"));
            return Created("Task",null);
        }  
    }
}
