using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Models.MalariaData
{
    [DataContract]
    public partial class DataIssuesDetail
    {
        [DataMember(Name ="UniqueId")]
        public int Id { get; set; }

        [DataMember(Name ="DataLoadId")]
        public int LoadId { get; set; }

        public int RecordNumber { get; set; }
        
        public string? ColumnName { get; set; }

        /// <summary>
        /// error or warning
        /// </summary>
        public string IssueType { get; set; }
        
        public string Issue { get; set; } = null!;

        public LoadStat Load { get; set; }
    }
}
