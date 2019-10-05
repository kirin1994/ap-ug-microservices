
using System.Collections.Generic;

namespace Eventdlar.Common.Queries
{
    public class Notifications : IQueryResponse
    {
        public IEnumerable<Notification> NotificationsList {get;set;}
        public Notifications() {}
        public Notifications(IList<Notification> notifications)
        {
            NotificationsList = notifications;
        }
    }
}
