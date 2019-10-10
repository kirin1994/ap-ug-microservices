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
               new Event("JS conf","JS meetup Dec 10!!!."),
               new Event(".NET Core","Krakow meetup!"),
               new Event("Ruby Conf","Opener festival is near."),
               new Event("Elixir","Functional programming in Gdynia."),
               new Event("Meet Haskell","Pure functional programming."),
               new Event("MongoDB","Learn about NoSQL!"),
               new Event("Kubecon","Kubernetes is here."),
               new Event("Dockero","Docker performance.")
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