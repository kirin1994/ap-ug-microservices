
using System.Collections.Generic;

namespace Eventdlar.Common.Queries
{
    public class Events : IQueryResponse
    {
        public IEnumerable<Event> EventsList {get;set;}
        public Events() {}
        public Events(IList<Event> events)
        {
            EventsList = events;
        }
    }
}
