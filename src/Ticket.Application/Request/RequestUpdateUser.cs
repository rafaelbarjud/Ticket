using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Application.Request
{
    public class RequestUpdateUser
    {
        public RequestUpdateUser()
        {
            Address = new List<RequestAddress>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public List<RequestAddress> Address { get; set; }
    }
}
