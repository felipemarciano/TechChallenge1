using Ardalis.Specification;

namespace TechChallenge1.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
