using System.Threading.Tasks;

namespace Eventdlar.Common.Events
{
    public class EventCreated : IEvent
    {
        public string Name {get;}
        public string Description {get;}
        public EventCreated(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
