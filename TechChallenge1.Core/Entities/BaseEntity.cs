namespace TechChallenge1.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
    }
}
