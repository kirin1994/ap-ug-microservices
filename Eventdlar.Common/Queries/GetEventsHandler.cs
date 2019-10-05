using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RawRabbit;

namespace Eventdlar.Common.Queries
{
    public class GetEventsHandler : IQueryHandler<GetEvents,Events>
    {
        private readonly IBusClient _clientBus;
        public GetEventsHandler(IBusClient clientBus)
        {
            _clientBus = clientBus;
        }

        public async Task<Events> HandleAsync(GetEvents query, IBusClient busClient)
        {
            await Task.Run(()=>Thread.Sleep(1));
            return new Events (new List<Event>{new Event("from query handler","udalo sie")});
        }
    }
}
