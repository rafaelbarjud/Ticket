using System;
using System.Collections.Generic;


namespace Ticket.Application.Request
{
    public class RequestUser
    {
        public RequestUser()
        {
            Address = new List<RequestAddress>();
        }

        public string Name {  get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public List<RequestAddress> Address { get; set; }
    }
}
