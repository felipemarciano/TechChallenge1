using TechChallenge1.Core.Constants;
using TechChallenge1.Core.Entities;

namespace TechChallenge1.Core.Interfaces
{
    public interface IProfileService
    {
        Task CreateUpdateProfileAsync(Profile profile);
    }
}
