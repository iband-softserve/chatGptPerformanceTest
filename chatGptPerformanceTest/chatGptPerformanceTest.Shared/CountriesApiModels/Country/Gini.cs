using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace chatGptPerformanceTest.Shared.CountriesApiModels.Country
{
    public class Gini
    {
        [JsonExtensionData]
        public Dictionary<string, JToken>? Years { get; set; }
    }
}
