using System.Threading.Tasks;

namespace Eventdlar.Common.Events
{
    public class NotificationSent : IEvent
    {
        public string Email {get;}
        public string Name {get;}
        public NotificationSent(string email, string name)
        {      
            Email = email;
            Name = name;
        }
    }
}
