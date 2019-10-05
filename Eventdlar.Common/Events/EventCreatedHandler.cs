using System;
using System.Threading.Tasks;
using Eventdlar.Common.Commands;
using RawRabbit;

namespace Eventdlar.Common.Events
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
            var sendNotification = new SendNotification("notificationsub@gmail.com",@event.Name);
            Console.WriteLine($"Sending SendNotification command: {@event.Name} {@event.Description}");
            _clientBus.PublishAsync(sendNotification, default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Commands")).WithRoutingKey("sendnotification.#"));
            return Task.CompletedTask;
        }
    }


}
