using System;
using System.Collections.Generic;

namespace Ticket.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Phone { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
