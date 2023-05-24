using System.Runtime.Serialization;

namespace Common.Models.MalariaData
{
    public partial class CasesReportedComplete
    {
        [DataMember(Name = "UniqueId")]
        public int Id { get; set; }
        
        [DataMember(Name ="DataLoadId")]
        public int LoadId { get; set; }
        
        public int RecordNumber { get; set; }

        public string Country { get; set; } = null!;
        
        public int Year { get; set; }

        [DataMember(Name ="NumberOfCases")]
        public int NumCases { get; set; }

        [DataMember(Name = "NumberOfDeaths")]
        public int NumDeaths { get; set; }

        [DataMember(Name = "WHO Region")]
        public string Region { get; set; } = null!;

        public LoadStat Load { get; set; }
    }
}
