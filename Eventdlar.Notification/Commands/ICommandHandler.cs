using System.Threading.Tasks;

namespace Eventdlar.Notification.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T @event);
    }
}
