namespace Eventdlar.Common.Queries
{
    public class Event 
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public Event(string name, string Description)
        {
            this.Name = name;
            this.Description = Description;
        }
    }
}
