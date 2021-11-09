using System;
using System.Collections.Generic;


namespace Ticket.Application.Request
{
    public class RequestUser
    {
        public RequestUser()
        {
            AddressList = new List<RequestAddress>();
        }

        public string Name {  get; set; }
        public string Email { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Phone { get; set; }
        List<RequestAddress> AddressList { get; set; }
    }
}
