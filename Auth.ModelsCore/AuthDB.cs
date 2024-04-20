using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Auth.ModelsCore
{
    public class AuthDB : DbContext
    {

        public DbSet<User> Users { get; set; }

        public AuthDB(DbContextOptions<AuthDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
