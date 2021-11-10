
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Models;

namespace Ticket.Data.Repository
{
    public  class RepositoryAddress : RepositoryBase<Address>, IRepositoryAddress
    {
        private readonly SqlContext _context;

        public RepositoryAddress(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Address> GetAddresByUserId(Guid userId)
        {
            return _context.Set<Address>().Where(x => x.User.Id.Equals(userId))
                .ToList();
        }
    }
}
