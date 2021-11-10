
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Models;

namespace Ticket.Data.Repository
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly SqlContext _context;

        public RepositoryUser(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public List<User> GetByName(string name)
        {
            return _context.Set<User>().Where(x => x.Name.Contains(name))
                .Include(x => x.Address)
                .ToList();
        }

        public User GetByIdWithAddress(Guid id)
        {
            return _context.Set<User>()
                .Where(x => x.Id == id)
                .Include(x => x.Address)
                .FirstOrDefault();
        }
    }
}
