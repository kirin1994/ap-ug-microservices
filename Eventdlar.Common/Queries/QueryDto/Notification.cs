using System;

namespace Eventdlar.Common.Queries
{
    public class Notification
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