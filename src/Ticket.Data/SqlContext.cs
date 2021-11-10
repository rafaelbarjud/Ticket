using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Models;

namespace Ticket.Data
{
    public partial class SqlContext : DbContext
    {

        public SqlContext(DbContextOptions<SqlContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.Phone)
                    .HasMaxLength(15);
                entity.Property(e => e.BirthDate);
                
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(9);
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(14);
                entity.Property(e => e.Street)
                    .HasMaxLength(150);
                entity.Property(e => e.Complement)
                    .HasMaxLength(150);
                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(50);
                entity.Property(e => e.City)
                    .HasMaxLength(50);
                entity.Property(e => e.State)
                    .HasMaxLength(50);
                entity.Property(e => e.Ibge)
                    .HasMaxLength(15);
                entity.Property(e => e.Gia)
                    .HasMaxLength(15);
                entity.Property(e => e.Ddd)
                    .HasMaxLength(15);
                entity.Property(e => e.Siafi)
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<User>()
                .HasMany(c => c.Address)
                .WithOne(e => e.User);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
