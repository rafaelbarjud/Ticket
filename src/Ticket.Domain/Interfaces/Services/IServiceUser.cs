
using System.Collections.Generic;
using Ticket.Domain.Models;

namespace Ticket.Domain.Interfaces.Services
{
    public interface IServiceUser : IServiceBase<User>
    {
        List<User> GetByName(string name);
    }
}
