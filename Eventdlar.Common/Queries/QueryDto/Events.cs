
using System.Collections.Generic;
using Eventdlar.Common.Databases;

namespace Eventdlar.Common.Queries
{
    public class Events : IQueryResponse, IEntity
    {
        public IList<Event> EventsList {get;set;}
        public Events() {}
        public Events(IList<Event> events)
        {
            EventsList = events;
        }
    }
}
