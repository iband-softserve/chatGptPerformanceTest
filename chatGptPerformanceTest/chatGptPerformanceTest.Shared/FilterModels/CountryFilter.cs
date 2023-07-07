namespace chatGptPerformanceTest.Shared.FilterModels
{
    public class CountryFilter
    {
        private string? countryName;
        private int? population;
        private string? sortType;
        private int? numberOfRecords;
        
        public string? CountryName
        {
            get => countryName;
            set => countryName = value;
        }

        public int? Population
        {
            get => population;
            set => population = value;
        }

        public string? SortType
        {
            get => sortType;
            set => sortType = value;
        }

        public int? NumberOfRecords
        {
            get => numberOfRecords; 
            set => numberOfRecords = value;
        }
    }
}
