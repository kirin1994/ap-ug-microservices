using System;
using System.Threading.Tasks;

namespace Eventdlar.Common.Events
{
    public class NotificationSentHandler : IEventHandler<NotificationSent>
    {
        public Task HandleAsync(NotificationSent @event)
        {
            Console.WriteLine($"Client {@event.Name} notified about event on address: {@event.Email} ");
            return Task.CompletedTask;
        }
    }
}
