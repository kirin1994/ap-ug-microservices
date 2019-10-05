using System;
using System.Threading.Tasks;
using Eventdlar.Common.Databases;
using eventsnamespace = Eventdlar.Common.Queries;
using Eventdlar.Common.Queries;
using RawRabbit;
using Eventdlar.Common.Events;

namespace Eventdlar.Common.Commands
{
    public class CreateEventHandler : ICommandHandler<CreateEvent>
    {
        private readonly IBusClient _clientBus;
        private readonly IRepository<Event, eventsnamespace.Events> _repository;

        public CreateEventHandler(IBusClient clientBus, IRepository<Event, eventsnamespace.Events> repository)
        {
            _clientBus = clientBus;
            _repository = repository;
        }

        public Task HandleAsync(CreateEvent @event)
        {
            _repository.add(new Event(@event.Name,@event.Description));
            var eventCreated = new EventCreated(@event.Name,@event.Description);
            Console.WriteLine($"Recived CreateEvent command: {@event.Name} {@event.Description}");
            _clientBus.PublishAsync(eventCreated, default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Events")).WithRoutingKey("eventcreated.#"));
            
            return Task.CompletedTask;
        }
    }
}
