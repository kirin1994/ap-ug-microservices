using System.Threading.Tasks;

namespace Eventdlar.Eventer.Commands
{
    public class CreateEvent : ICommand
    {
        public string Name {get;}
        public string Description {get;}
        public CreateEvent(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
