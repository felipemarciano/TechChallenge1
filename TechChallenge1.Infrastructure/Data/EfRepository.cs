using Ardalis.Specification.EntityFrameworkCore;
using TechChallenge1.Core.Interfaces;

namespace TechChallenge1.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(TechDbContext dbContext) : base(dbContext)
        {
        }
    }
}
