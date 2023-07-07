using chatGptPerformanceTest.Shared.Abstract.Repositories;
using chatGptPerformanceTest.Shared.Abstract.Services;
using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatGptPerformanceTest.Services.Implementation
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository countriesRepository;

        public CountriesService(ICountriesRepository countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task<List<Country>?> GetAllCountries(string? countryName, int? population, string? sortType, int? numberOfRecords)
        {
            var countries = await countriesRepository.GetAllCountries();
            
            if(countries == null)
            {
                return new List<Country>();
            }

            return countries;
        }

    }
}
