using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatGptPerformanceTest.Shared.Abstract.Services
{
    public interface ICountriesService
    {
        public Task<List<Country>?> GetAllCountries(string? countryName, int? population, string? sortType, int? numberOfRecords);
    }
}
