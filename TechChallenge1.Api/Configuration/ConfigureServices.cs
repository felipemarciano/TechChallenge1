using Microsoft.AspNetCore.Identity;
using System.Text;
using TechChallenge1.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace TechChallenge1.Api.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            Infrastructure.Dependencies.ConfigureServices(configuration, services);

           // Add Identity
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            // Configure JWT authentication
            var jwtSettings = configuration.GetSection("JwtSettings");
            string? secretKey = jwtSettings.GetSection("Secret").Value;

            if (secretKey == null)
                throw new Exception("Not found jwtsettings secret");

            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            return services;
        }

    }
}
