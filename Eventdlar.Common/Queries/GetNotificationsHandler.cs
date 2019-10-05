using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RawRabbit;

namespace Eventdlar.Common.Queries
{
    public class GetNotificationsHandler : IQueryHandler<GetNotifications,Notifications>
    {
        private readonly IBusClient _clientBus;
        public GetNotificationsHandler(IBusClient clientBus)
        {
            _clientBus = clientBus;
        }

        public async Task<Notifications> HandleAsync(GetNotifications query, IBusClient busClient)
        {
            await Task.Run(()=>Thread.Sleep(1));
            return new Notifications (new List<Notification>{new Notification("test@gmail.com","Wyslano powiadomienie na podany adres.")});
        }
    }
}
