namespace chatGptPerformanceTest.Shared.FilterModels
{
    public class CountryFilter
    {        
        public string? CountryName;
        public int? Population;
        public string? SortType;
        public int? NumberOfRecords;

        public CountryFilter()
        {
            CountryName = null;
            Population = null;
            SortType = null;
            NumberOfRecords = null;
        }
    }
}
