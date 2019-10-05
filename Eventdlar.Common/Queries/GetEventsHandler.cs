using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eventdlar.Common.Databases;
using RawRabbit;

namespace Eventdlar.Common.Queries
{
    public class GetEventsHandler : IQueryHandler<GetEvents,Events>
    {
        private readonly IBusClient _clientBus;
        private readonly IRepository<Event, Events> _repository;

        public GetEventsHandler(IBusClient clientBus, IRepository<Event,Events> repository)
        {
            _clientBus = clientBus;
            _repository = repository;
        }

        public async Task<Events> HandleAsync(GetEvents query, IBusClient busClient)
        {
            await Task.Run(()=>Thread.Sleep(1));
            return _repository.getAll();
        }
    }
}
