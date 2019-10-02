using System.Threading.Tasks;

namespace Eventdlar.Eventer.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T @event);
    }
}
