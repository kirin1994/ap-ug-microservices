using System;
using System.Threading.Tasks;
using RawRabbit;

namespace Eventdlar.Common.Commands
{
    public class CreateEventHandler : ICommandHandler<CreateEvent>
    {
        private readonly IBusClient _clientBus;
        public CreateEventHandler(IBusClient clientBus)
        {
            _clientBus = clientBus;
        }

        public Task HandleAsync(CreateEvent @event)
        {
            Console.WriteLine($"Recived CreateEvent command: {@event.Name} {@event.Description}");
            return Task.CompletedTask;
        }
    }
}
