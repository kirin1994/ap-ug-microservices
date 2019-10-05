using System.Collections.Generic;
using Eventdlar.Common.Queries;
using eventnamespace = Eventdlar.Common.Queries;

namespace Eventdlar.Common.Databases
{
    public class EventsInMemoryDb : IRepository<Event, eventnamespace.Events>
    {
        private static eventnamespace.Events Events = new eventnamespace.Events 
        (
           new List<Event>{
               new Event(".NET CONF","New event in Gdansk."),
               new Event("Opener festival","Opener festival is near."),
               new Event("JS conf","JS meetup Dec 10!!!.")
               }
        );
        public void add(Event @event)
        {
            Events.EventsList.Add(@event);
        }

        public eventnamespace.Events getAll()
        { 
            return Events;
        }
    }
}