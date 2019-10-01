using System.Threading.Tasks;

namespace Eventdlar.Api.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T @event);
    }
}
