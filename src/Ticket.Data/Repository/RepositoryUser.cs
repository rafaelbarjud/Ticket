
using System.Collections.Generic;
using System.Linq;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Models;

namespace Ticket.Data.Repository
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly SqlContext _context;

        public RepositoryUser(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public List<User> GetByName(string name)
        {
            return _context.Set<User>().Where(x => x.Name == name).ToList();
        }
    }
}
