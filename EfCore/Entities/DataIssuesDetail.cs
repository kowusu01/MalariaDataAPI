using System;
using System.Collections.Generic;

namespace EfCoreLayer.Entities
{
    public partial class DataIssuesDetail
    {
        public int Id { get; set; }
        public int LoadId { get; set; }
        public int RecordNumber { get; set; }
        public string? ColumnName { get; set; }
        public string Issue { get; set; } = null!;
    }
}
