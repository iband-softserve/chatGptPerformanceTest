using chatGptPerformanceTest.Shared.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatGptPerformanceTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountryController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> Get(
            [FromQuery] string? name,
            [FromQuery] int? population,
            [FromQuery] string? sortType,
            [FromQuery] int? numberOfRecords)
        {
            return Ok(await _countriesService.GetAllCountries(name, population, sortType, numberOfRecords));
        }
    }
}
