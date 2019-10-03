using System.Threading.Tasks;

namespace Eventdlar.Common.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
