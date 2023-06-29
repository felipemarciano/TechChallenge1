using System.Net.Http.Headers;

namespace TechChallenge1.Web.Data
{
    public class ProfileService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ProfileService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ProfileModel?> Get()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["authToken"];

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var request = await _httpClient.GetAsync("api/profile");

            if (request.IsSuccessStatusCode)
            {
                var profileModel = await request.Content.ReadFromJsonAsync<ProfileModel>();

                return profileModel;
            }
            else
            {
                return null;
            }            
        }
    }
}