using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using chatGptPerformanceTest.Shared.FilterModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatGptPerformanceTest.Shared.Abstract.Services
{
    public interface ICountriesService
    {
        public Task<List<Country>?> GetCountries(CountryFilter countryFilter);
    }
}
