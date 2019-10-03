using System.Threading.Tasks;

namespace Eventdlar.Common.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T @event);
    }
}
