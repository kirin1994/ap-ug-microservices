using System.Threading.Tasks;

namespace Eventdlar.Common.Commands
{
    public class SendNotification : ICommand
    {
        public string Email {get; set;}
        public string Text {get; set;}
        public SendNotification(){}
        public SendNotification(string email, string text)
        {
            Email = email;
            Text = text;
        }
    }
}
