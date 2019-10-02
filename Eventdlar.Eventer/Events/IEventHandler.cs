using System.Threading.Tasks;

namespace Eventdlar.Eventer.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
