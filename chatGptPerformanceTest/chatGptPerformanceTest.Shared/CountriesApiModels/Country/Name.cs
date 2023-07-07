using System.Collections.Generic;

namespace chatGptPerformanceTest.Shared.CountriesApiModels.Country
{

    public class Name
    {
        public string? common { get; set; }
        public string? official { get; set; }
        public Dictionary<string, Language>? nativeName { get; set; }
    }
}
