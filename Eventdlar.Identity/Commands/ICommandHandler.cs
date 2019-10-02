using System.Threading.Tasks;

namespace Eventdlar.Identity.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T @event);
    }
}
