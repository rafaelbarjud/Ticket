using System.Collections.Generic;
using Ticket.Domain.Models;

namespace Ticket.Domain.Interfaces.Repository
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        List<User> GetByName(string name);
    }
}
