using CreditS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TransactionData> TransactionsData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginInfo>()
                .HasIndex(x => x.Username).IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.PhoneNumber).IsUnique();
            modelBuilder.Entity<User>()
                .Property(x => x.Credits).HasDefaultValue(100);

            modelBuilder.Entity<Role>()
                .HasIndex(x => x.RoleDescription).IsUnique();

            modelBuilder.Entity<TransactionData>()
                .HasOne(x => x.SendingUser).WithMany(x => x.SentTransactionsData).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<TransactionData>()
                .HasOne(x => x.ReceivingUser).WithMany(x => x.ReceivedTransactionsData).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
