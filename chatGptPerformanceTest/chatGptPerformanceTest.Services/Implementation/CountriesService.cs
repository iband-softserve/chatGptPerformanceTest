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
            
            if (countries == null)
            {
                return new List<Country>();
            }

            if (!string.IsNullOrEmpty(countryName))
            {
                countries = FilterByName(countries, countryName);
            }

            return countries;
        }

        private List<Country> FilterByName(List<Country> countries, string countryName)
        {
            countryName = countryName.ToLower();
            return countries.Where(country => country.name != null && country.name.common != null && country.name.common.ToLower().Contains(countryName)).ToList();
        }
    }
}
