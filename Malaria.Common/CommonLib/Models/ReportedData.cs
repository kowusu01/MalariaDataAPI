namespace Common.Models.Malaria
{
    public partial class ReportedData
    {
        public int Id { get; set; }
        public int LoadId { get; set; }
        public int RecordNumber { get; set; }

        public string Country { get; set; } = null!;
        public string? CountryCode { get; set; } = null!;
        
        public int Year { get; set; }
        public int NumCases { get; set; }
        public int NumDeaths { get; set; }

        public string Region { get; set; } = null!;
        public string? RegionCode { get; set; } = null!;
        
        
        public LoadStat Load { get; set; }
    }
}
