
using System.Collections.Generic;
using Eventdlar.Common.Databases;

namespace Eventdlar.Common.Queries
{
    public class Notifications : IQueryResponse
    {
        public IList<Notification> NotificationsList {get;set;}
        public Notifications() {}
        public Notifications(IList<Notification> notifications)
        {
            NotificationsList = notifications;
        }
    }
}
