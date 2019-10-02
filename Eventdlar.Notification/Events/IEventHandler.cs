using System.Threading.Tasks;

namespace Eventdlar.Notification.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
