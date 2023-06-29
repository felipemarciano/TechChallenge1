using Ardalis.Specification;
using TechChallenge1.Core.Entities;

namespace TechChallenge1.Core.Specifications
{
    public sealed class ProfileApplicationUserIdSpecification : Specification<Profile>, ISingleResultSpecification<Profile>
    {
        public ProfileApplicationUserIdSpecification(Guid applicationUserId)
        {
            Query.
                Where(u => u.ApplicationUserId != applicationUserId);
        }
    }
}
