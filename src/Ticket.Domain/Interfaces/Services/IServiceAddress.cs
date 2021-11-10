

using System;
using System.Collections.Generic;
using Ticket.Domain.Models;

namespace Ticket.Domain.Interfaces.Services
{
    public interface IServiceAddress : IServiceBase<Address>
    {
        List<Address> GetAddressByUserId(Guid userId);
    }
}
