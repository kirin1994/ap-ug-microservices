using System;
using System.Threading.Tasks;

namespace Eventdlar.Notification.Events
{
    public class EmailSentToClientHandler : IEventHandler<EmailSentToClient>
    {
        public Task HandleAsync(EmailSentToClient @event)
        {
            Console.WriteLine($"Client {@event.Name} notified about event on address: {@event.Email} ");
            return Task.CompletedTask;
        }
    }
}
