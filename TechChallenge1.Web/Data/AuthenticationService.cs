namespace TechChallenge1.Web.Data
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var result = await _httpClient.PostAsJsonAsync("api/account/login", new { username, password });
            result.EnsureSuccessStatusCode();

            var jwtToken = await result.Content.ReadFromJsonAsync<RToken>() ?? new();
            return jwtToken.AccessToken ?? "";
        }

        private class RToken
        {
            public string? AccessToken { get; set; }
        }
    }
}
