using Ardalis.Specification;

namespace TechChallenge1.Core.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
