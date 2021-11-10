using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Application.Response
{
    public class ResponseUser
    {
        public ResponseUser()
        {
            Address = new List<ResponseAddress>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }

        public List<ResponseAddress> Address { get; set; }
    }
}
