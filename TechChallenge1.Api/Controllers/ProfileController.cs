using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechChallenge1.Api.Model;
using TechChallenge1.Core.Constants;
using TechChallenge1.Core.Entities;
using TechChallenge1.Core.Interfaces;
using TechChallenge1.Core.Specifications;

namespace TechChallenge1.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileService;
        private readonly IReadRepository<Profile> _profileRepository;

        public ProfileController(ILogger<ProfileController> logger, IReadRepository<Profile> profileRepository, IProfileService profileService)
        {
            _logger = logger;
            _profileRepository = profileRepository;
            _profileService = profileService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            string? userId = User?.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var profile = await _profileRepository.FirstOrDefaultAsync(new ProfileApplicationUserIdSpecification(Guid.Parse(userId)));

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(new ProfileResponse
            {
                Id = profile.Id,
                ApplicationUserId = profile.ApplicationUserId,
                Biography = profile.Biography,
                DateCreate = profile.DateCreate,
                DateUpdate = profile.DateUpdate,
                Gender = profile.Gender.ToString(),
                PictureUri = profile.PictureUri,
                UserName = profile.UserName
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProfileRequest profileRequest)
        {
            string? userId = User?.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            await _profileService.CreateUpdateProfileAsync(
                new Profile(Guid.Parse(userId),
                                profileRequest.UserName ?? "",
                                profileRequest.Biography,
                                string.Empty,
                                Enum.Parse<EGender>(profileRequest.Gender ?? EGender.NaoInformado.ToString())));
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ProfileRequest profileRequest)
        {
            string? userId = User?.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            if(profileRequest.PictureUri == null)
            {
                throw new Exception("Picture is required!");
            }

            await _profileService.UpdatePictureUriAsync(Guid.Parse(userId), profileRequest.PictureUri);

            return Ok();
        }
    }
}

