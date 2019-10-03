using System.Threading.Tasks;

namespace Eventdlar.Common.Events
{
    public class EmailSentToClient : IEvent
    {
        public string Email {get;}
        public string Name {get;}
        public EmailSentToClient(string email, string name)
        {      
            Email = email;
            Name = name;
        }
    }
}
