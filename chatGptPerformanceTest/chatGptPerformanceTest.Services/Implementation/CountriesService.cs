using chatGptPerformanceTest.Shared.Abstract.Repositories;
using chatGptPerformanceTest.Shared.Abstract.Services;
using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using chatGptPerformanceTest.Shared.FilterModels;
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

        public async Task<List<Country>?> GetCountries(CountryFilter countryFilter)
        {
            var countries = await countriesRepository.GetAllCountries();
            
            if (countries == null)
            {
                return new List<Country>();
            }

            if (!string.IsNullOrEmpty(countryFilter.CountryName))
            {
                countries = FilterByName(countries, countryFilter.CountryName.ToLower());
            }

            if (countryFilter.Population.HasValue)
            {
                countries = FilterByPopulation(countries, countryFilter.Population.Value * 1000000);
            }

            if (!string.IsNullOrEmpty(countryFilter.SortType))
            {
                countries = SortByCountryName(countries, countryFilter.SortType.ToLower());
            }

            if (countryFilter.NumberOfRecords.HasValue)
            {
                countries = ApplyPagination(countries, countryFilter.NumberOfRecords.Value);
            }

            return countries;
        }

        private List<Country> FilterByName(List<Country> countries, string countryName)
        {
            return countries.Where(country => country.name.common != null && country.name.common.ToLower().Contains(countryName)).ToList();
        }
        
        private List<Country> FilterByPopulation(List<Country> countries, int population)
        {
            return countries.Where(country => country.population < population).ToList();
        }

        private List<Country> SortByCountryName(List<Country> countries, string sortType)
        {
            if (sortType == "ascend")
            {
                return countries.OrderBy(country => country.name.common).ToList();
            }
            else if (sortType == "descend")
            {
                return countries.OrderByDescending(country => country.name.common).ToList();
            }

            return countries;
        }

        private List<Country> ApplyPagination(List<Country> countries, int numberOfRecords)
        {
            return countries.Take(numberOfRecords).ToList();
        }
    }
}
