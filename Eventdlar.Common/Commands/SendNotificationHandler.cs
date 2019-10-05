using System;
using System.Threading.Tasks;
using Eventdlar.Common.Databases;
using eventsnamespace = Eventdlar.Common.Queries;
using Eventdlar.Common.Queries;
using RawRabbit;
using Eventdlar.Common.Events;

namespace Eventdlar.Common.Commands
{
    public class SendNotificationHandler : ICommandHandler<SendNotification>
    {
        private readonly IBusClient _clientBus;
        private readonly IRepository<Notification, Notifications > _repository;

        public SendNotificationHandler(IBusClient clientBus, IRepository<Notification, Notifications> repository)
        {
            _clientBus = clientBus;
            _repository = repository;
        }

        public Task HandleAsync(SendNotification notification)
        {
            _repository.add(new Notification(notification.Email, notification.Text));
            var notificationSent = new NotificationSent(notification.Email,notification.Text);
            Console.WriteLine($"Sending NotificationSent event: {@notification.Email} {notification.Text}");
            _clientBus.PublishAsync(notificationSent, default(Guid), 
            cfg => cfg.WithExchange(ex => ex.WithName("Events")).WithRoutingKey("notificationsent.#"));
            
            return Task.CompletedTask;
        }
    }
}
