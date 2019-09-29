using System.Threading.Tasks;

namespace Eventdlar.Common.Domain.Event
{
    public interface IEventHandler<in T> where T :IEvent 
    {
        Task HandleAsync(T @event);
    }
}
