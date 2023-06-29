using Microsoft.EntityFrameworkCore;


namespace TechChallenge1.Infrastructure.Data
{
    public class TechDbContextSeed
    {
        public static void Seed(TechDbContext techDbContext)
        {
            if (techDbContext.Database.IsSqlServer())
            {
                techDbContext.Database.Migrate();
            }
        }
    }
}
