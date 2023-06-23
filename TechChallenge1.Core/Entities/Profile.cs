using Ardalis.GuardClauses;
using TechChallenge1.Core.Constants;
using TechChallenge1.Core.Interfaces;

namespace TechChallenge1.Core.Entities
{
    public class Profile : BaseEntity, IAggregateRoot
    {
        public Profile(Guid applicationUserId, string userName, string? biography, string pictureUri, EGender gender)
        {
            Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            Guard.Against.NullOrEmpty(userName, nameof(userName));

            ApplicationUserId = applicationUserId;
            UserName = userName;
            Biography = biography;
            PictureUri = pictureUri;
            DateCreate = DateTime.Now;
            Gender = gender;
        }

        public Guid ApplicationUserId { get; private set; }
        public string UserName { get; private set; }
        public string? Biography { get; private set; }
        public string? PictureUri { get; private set; }
        public EGender Gender { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime? DateUpdate { get; private set; }

        public void ChangePictureUri(string pictureUri)
        {
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            PictureUri = pictureUri;
            AddDateUpdate();
        }

        public void ChangeProfile(string userName, string biography)
        {
            Guard.Against.NullOrEmpty(userName, nameof(userName));

            UserName = userName;
            Biography = biography;
            AddDateUpdate();
        }

        private void AddDateUpdate()
        {
            DateUpdate = DateTime.Now;
        }
    }
}
