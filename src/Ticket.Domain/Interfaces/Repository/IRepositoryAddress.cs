using System;
using System.Collections.Generic;
using Ticket.Domain.Models;

namespace Ticket.Domain.Interfaces.Repository
{
    public interface IRepositoryAddress : IRepositoryBase<Address>
    {
        List<Address> GetAddresByUserId(Guid userId);
    }
}
