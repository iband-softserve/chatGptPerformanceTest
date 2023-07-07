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
                countries = FilterByName(countries, countryName.ToLower());
            }

            if (population.HasValue)
            {
                countries = FilterByPopulation(countries, population.Value * 1000000);
            }

            return countries;
        }

        private List<Country> FilterByName(List<Country> countries, string countryName)
        {
            return countries.Where(country => country.name != null && country.name.common != null && country.name.common.ToLower().Contains(countryName)).ToList();
        }
        
        private List<Country> FilterByPopulation(List<Country> countries, int population)
        {
            return countries.Where(country => country.population < population).ToList();
        }
    }
}
