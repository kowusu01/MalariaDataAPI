using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Common.Models.MalariaData
{
    public partial class CasesReportedBad
    {
        [DataMember(Name = "UniqueId")]
        public int Id { get; set; }

        [DataMember(Name = "DataLoadId")]
        public int LoadId { get; set; }

        public int RecordNumber { get; set; }

        public string? Country { get; set; }
        
        public string? Year { get; set; }

        [DataMember(Name = "NumberOfCases")]
        public string? NumCases { get; set; }

        [DataMember(Name = "NumberOfDeaths")]
        public string? NumDeaths { get; set; }

        [DataMember(Name = "WHO Region")]
        public string? Region { get; set; }

        public LoadStat Load { get; set; }
    }
}
