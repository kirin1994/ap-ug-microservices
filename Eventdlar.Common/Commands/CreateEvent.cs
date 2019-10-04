using System.Threading.Tasks;

namespace Eventdlar.Common.Commands
{
    public class CreateEvent : ICommand
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public CreateEvent(){}
        public CreateEvent(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
