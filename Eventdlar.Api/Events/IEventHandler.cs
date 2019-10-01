using System.Threading.Tasks;

namespace Eventdlar.Api.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
