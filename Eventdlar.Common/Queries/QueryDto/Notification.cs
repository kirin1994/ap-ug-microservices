using System;
using Eventdlar.Common.Databases;

namespace Eventdlar.Common.Queries
{
    public class Notification : IEntity
    {
        public string Email {get;set;}
        public string Text {get;set;}
        public Notification(string email, string text)
        {
            this.Email = email;
            this.Text = text;
        }
    }
}