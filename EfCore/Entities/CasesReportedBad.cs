using System;
using System.Collections.Generic;

namespace EfCoreLayer.Entities
{
    public partial class CasesReportedBad
    {
        public int Id { get; set; }
        public int LoadId { get; set; }
        public int RecordNumber { get; set; }
        public string? Country { get; set; }
        public string? Year { get; set; }
        public string? NumCases { get; set; }
        public string? NumDeaths { get; set; }
        public string? Region { get; set; }
    }
}
