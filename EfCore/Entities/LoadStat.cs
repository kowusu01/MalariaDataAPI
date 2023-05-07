using System;
using System.Collections.Generic;

namespace EfCoreLayer.Entities
{
    public partial class LoadStat
    {
        public int Id { get; set; }
        public string? Descr { get; set; }
        public DateTime LoadTimestamp { get; set; }
        public string? FilePath { get; set; }
        public bool Completed { get; set; }
        public int NumRecords { get; set; }
        public int BadDataCount { get; set; }
        public int? WarningDataCount { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
