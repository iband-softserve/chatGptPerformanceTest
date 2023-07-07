using chatGptPerformanceTest.Repositories.Implementation;
using chatGptPerformanceTest.Services.Implementation;
using chatGptPerformanceTest.Shared.Abstract.Repositories;
using chatGptPerformanceTest.Shared.Abstract.Services;
using chatGptPerformanceTest.Shared.CountriesApiModels.Country;
using chatGptPerformanceTest.Shared.FilterModels;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace chatGptPerformanceTest.UnitTests
{
    [TestClass]
    public class CountriesServiceTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private ICountriesRepository countriesRepository;
        private ICountriesService countriesService;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void TestInitialize()
        {
            countriesRepository = A.Fake<ICountriesRepository>();
            countriesService = new CountriesService(countriesRepository);
        }


        [TestMethod]
        public async Task GetCountries_WithNoDataProvided_ReturnsAllCountries()
        {
            // Arange
            var allCountries = new List<Country>()
            {
                new Country()
                {
                    name = new Name()
                    {
                        common = "Ukraine"
                    }
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United Kingdom"
                    }
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United States"
                    }
                }
            };

            A.CallTo(() => countriesRepository.GetAllCountries())
                .Returns(allCountries);

            var filters = new CountryFilter();

            // Act
            var result = await countriesService.GetCountries(filters);

            // Assert
            result.ShouldBe(allCountries);
        }

        [TestMethod]
        public async Task GetCountries_WithCountryNameFilter_ReturnsFilteredCountries()
        {
            // Arange
            var allCountries = new List<Country>()
            {
                new Country()
                {
                    name = new Name()
                    {
                        common = "Ukraine"
                    }
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United Kingdom"
                    }
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United States"
                    }
                }
            };

            A.CallTo(() => countriesRepository.GetAllCountries())
                .Returns(allCountries);

            var filters = new CountryFilter()
            {
                CountryName = "sta"
            };

            // Act
            var result = await countriesService.GetCountries(filters);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result[0].name.common.ShouldBe("United States");
        }

        [TestMethod]
        public async Task GetCountries_WithCountryPopulationFilter_ReturnsFilteredCountries()
        {
            // Arange
            var allCountries = new List<Country>()
            {
                new Country()
                {
                    name = new Name()
                    {
                        common = "Ukraine"
                    },
                    population = 1000000
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United Kingdom"
                    },
                    population = 10000000
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United States"
                    },
                    population = 8000000
                }
            };

            A.CallTo(() => countriesRepository.GetAllCountries())
                .Returns(allCountries);

            var filters = new CountryFilter()
            {
                Population = 9
            };

            // Act
            var result = await countriesService.GetCountries(filters);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result.ShouldAllBe(country => country.population < 9000000);
        }

        [TestMethod]
        public async Task GetCountries_WithPaging_ReturnsFirstNCountries()
        {
            // Arange
            var allCountries = new List<Country>()
            {
                new Country()
                {
                    name = new Name()
                    {
                        common = "Ukraine"
                    },
                    population = 1000000
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United Kingdom"
                    },
                    population = 10000000
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United States"
                    },
                    population = 8000000
                }
            };

            A.CallTo(() => countriesRepository.GetAllCountries())
                .Returns(allCountries);

            var filters = new CountryFilter()
            {
                NumberOfRecords = 2
            };

            // Act
            var result = await countriesService.GetCountries(filters);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
        }

        [TestMethod]
        public async Task GetCountries_WithOrderBy_ReturnsOrderedCountries()
        {
            // Arange
            var allCountries = new List<Country>()
            {
                new Country()
                {
                    name = new Name()
                    {
                        common = "Ukraine"
                    },
                    population = 1000000
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United Kingdom"
                    },
                    population = 10000000
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "United States"
                    },
                    population = 8000000
                }
            };

            A.CallTo(() => countriesRepository.GetAllCountries())
                .Returns(allCountries);

            var filters = new CountryFilter()
            {
                SortType = "ascend"
            };

            // Act
            var result = await countriesService.GetCountries(filters);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
            result.SequenceEqual(allCountries.OrderBy(country => country.name.common)).ShouldBeTrue();
        }
    }
}