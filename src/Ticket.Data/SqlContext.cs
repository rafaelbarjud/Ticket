using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Domain.Models;

namespace Ticket.Data
{
    public  class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
