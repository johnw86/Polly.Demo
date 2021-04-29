using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Polly.Demo
{
    public class ProfileService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetProfileAsync(string username)
        {
            var client = _httpClientFactory.CreateClient("GitHub");

            var response = await client.GetStringAsync($"users/{username}");

            Console.Write(response);
        }
    }
}
