using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace chatGptPerformanceTest.Repositories.Common
{
    public abstract class BaseRepository
    {
        private readonly string BaseUrl;
        private readonly HttpClient Client;

        protected BaseRepository(string baseUrl, HttpClient client)
        {
            BaseUrl = baseUrl;
            Client = client;
        }

        protected async Task<T?> SendGetRequest<T>(string route) where T : class 
        {
            var response = await Client.GetAsync($"{BaseUrl}/{route}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseBody);
            return result == null ? default(T) : result;
        }
    }
}
