namespace Common.Models.Malaria
{
    public partial class DataIssuesDetail
    {
        public int Id { get; set; }

        public int LoadId { get; set; }

        public int RecordNumber { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public int? Year { get; set; }
        public int? NumCases { get; set; }
        public int? NumDeaths { get; set; }

        public string? ColumnName { get; set; }
        /// <summary>
        /// error or warning
        /// </summary>
        public string IssueType { get; set; }
        public string IssueCode { get; set; }
        public string Issue { get; set; } = null!;

        public LoadStat Load { get; set; }
    }
}
