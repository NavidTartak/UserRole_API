using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.Domain.Models
{
    public class Context : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
