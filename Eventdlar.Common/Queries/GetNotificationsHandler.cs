using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eventdlar.Common.Databases;
using RawRabbit;

namespace Eventdlar.Common.Queries
{
    public class GetNotificationsHandler : IQueryHandler<GetNotifications,Notifications>
    {
        private readonly IBusClient _clientBus;
        private readonly IRepository<Notification,Notifications> _repository;
        public GetNotificationsHandler(IBusClient clientBus, IRepository<Notification,Notifications> repository)
        {
            _clientBus = clientBus;
            _repository = repository;
        }

        public async Task<Notifications> HandleAsync(GetNotifications query, IBusClient busClient)
        {
            await Task.Run(()=>Thread.Sleep(1));
            return _repository.getAll();
        }
    }
}
