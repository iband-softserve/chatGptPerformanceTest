using chatGptPerformanceTest.Repositories.Common;
using chatGptPerformanceTest.Shared.Abstract.Repositories;
using chatGptPerformanceTest.Shared.ConfigurationModels;
using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace chatGptPerformanceTest.Repositories.Implementation
{
    public class CountriesRepository : BaseRepository, ICountriesRepository
    {
        private static string GetAllCountriesRoute = "v3.1/all";

        public CountriesRepository(CountriesApiConfiguration countriesApiConfiguration, HttpClient httpClient) 
            : base(countriesApiConfiguration.ApiBaseUrl ?? string.Empty, httpClient)
        {
        }

        public async Task<List<Country>?> GetAllCountries()
        {
            return await SendGetRequest<List<Country>>(GetAllCountriesRoute);
        }
    }
}
