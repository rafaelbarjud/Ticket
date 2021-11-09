using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Models;

namespace Ticket.Data.Repository
{
    public  class RepositoryAddress : RepositoryBase<Address>, IRepositoryAddress
    {
        private readonly SqlContext _context;

        public RepositoryAddress(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
