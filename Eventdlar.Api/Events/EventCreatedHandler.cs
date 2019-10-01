using System;
using System.Threading.Tasks;
using RawRabbit;

namespace Eventdlar.Api.Events
{
    public class EventCreatedHandler : IEventHandler<EventCreated>
    {
        private readonly IBusClient _clientBus;
        public EventCreatedHandler(IBusClient clientBus)
        {
            _clientBus = clientBus;
        }

        public Task HandleAsync(EventCreated @event)
        {
            Console.WriteLine("Event created");
            return Task.CompletedTask;
        }
    }


}
