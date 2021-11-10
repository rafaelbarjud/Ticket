using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Application.Response
{
    public class ResponseAddress
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ZipCode { get; set; }
        public string Category { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }
    }
}
