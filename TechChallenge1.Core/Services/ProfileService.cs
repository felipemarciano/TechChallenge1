using TechChallenge1.Core.Constants;
using TechChallenge1.Core.Entities;
using TechChallenge1.Core.Exceptions;
using TechChallenge1.Core.Interfaces;
using TechChallenge1.Core.Specifications;

namespace TechChallenge1.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<Profile> _profileRepository;

        public ProfileService(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task CreateProfileAsync(Guid applicationUserId, string userName, string pictureUri, string? biography, EGender gender)
        {
            var profileUserNameSpecification = new ProfileUserNameSpecification(userName, applicationUserId);
            var profileDmp = await _profileRepository.CountAsync(profileUserNameSpecification);
            if (profileDmp > 0)
            {
                throw new DuplicateException($"User already exists {userName}");
            }

            var profile = new Profile(applicationUserId, userName, biography, pictureUri, gender);

            await _profileRepository.AddAsync(profile);
        }
    }
}
