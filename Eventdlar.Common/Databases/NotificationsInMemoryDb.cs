using System.Collections.Generic;
using Eventdlar.Common.Queries;

namespace Eventdlar.Common.Databases
{
    public class NotificationsInMemoryDb : IRepository<Notification, Notifications>
    {
        private static Notifications Notifications = new Notifications 
        (
           new List<Notification>{
               new Notification("test@gmail.com","New event in Gdansk."),
               new Notification("adrian@gmail.com","Opener festival is near."),
               new Notification("karol@gmail.com","JS meetup Dec 10!!!.")
               }
        );
        public void add(Notification notification){
            Notifications.NotificationsList.Add(notification);
        }
        public Notifications getAll()
        { 
            return Notifications;
        }
    }
}
