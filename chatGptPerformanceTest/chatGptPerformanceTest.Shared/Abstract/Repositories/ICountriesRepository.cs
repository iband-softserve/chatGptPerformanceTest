using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatGptPerformanceTest.Shared.Abstract.Repositories
{
    public interface ICountriesRepository
    {
        public Task<List<Country>?> GetAllCountries();
    }
}
