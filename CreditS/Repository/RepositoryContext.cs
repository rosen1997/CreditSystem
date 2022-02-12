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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginInfo>()
                .HasIndex(x => x.Username).IsUnique();
        }
    }
}
