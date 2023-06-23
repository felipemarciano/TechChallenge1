using TechChallenge1.Core.Constants;

namespace TechChallenge1.Core.Interfaces
{
    public interface IProfileService
    {
        Task CreateProfileAsync(Guid applicationUserId, string userName, string pictureUri, string? biography, EGender gender);
    }
}
