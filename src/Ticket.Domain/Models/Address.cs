namespace Ticket.Domain.Models
{
    public  class Address : BaseEntity
    {
        public string Cep { get; set; }
        public string Category { get; set; }
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public User User { get; set; }

    }
}
