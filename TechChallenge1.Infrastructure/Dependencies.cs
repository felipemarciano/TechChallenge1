using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge1.Core.Interfaces;
using TechChallenge1.Infrastructure.Data;
using TechChallenge1.Infrastructure.Identity;

namespace TechChallenge1.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {

            // Add DataContext
            var techString = configuration.GetConnectionString("TechConnection") ?? throw new InvalidOperationException("Connection string 'TechConnection' not found.");
            services.AddDbContext<TechDbContext>(c =>
                c.UseSqlServer(techString));

            // Add Identity
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(connectionString));

            //Add Repository
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
