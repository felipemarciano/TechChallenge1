using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechChallenge1.Core.Entities;

namespace TechChallenge1.Infrastructure.Data
{
    public class TechDbContext : DbContext
    {
        public TechDbContext(DbContextOptions<TechDbContext> options) : base(options) { }

        public DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
