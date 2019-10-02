using System.Threading.Tasks;

namespace Eventdlar.Identity.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
