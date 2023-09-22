
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Common.Models.Malaria
{
    [DataContract]
    public partial class LoadStat
    {
        [DataMember(Name ="UniqueId")]
        [JsonPropertyOrder(1)]
        public int Id { get; set; }

        [DataMember(Name = "Region")]
        [JsonPropertyOrder(2)]
        public string? Region { get; set; }

        [DataMember]
        [JsonPropertyOrder(3)]
        public DateTime LoadTimestamp { get; set; }

        [DataMember(Name = "DataFilePath")]
        [JsonPropertyOrder(4)]
        public string? FilePath { get; set; }

        [JsonPropertyOrder(5)]
        public string LoadStatus { get; set; }

        [DataMember(Name = "TotalRecords")]
        [JsonPropertyOrder(6)]
        public int NumRecords { get; set; }

        [DataMember(Name = "BadRecords")]
        [JsonPropertyOrder(7)]
        public int BadDataCount { get; set; }

        [DataMember(Name = "RecordsWithWarnings")]
        [JsonPropertyOrder(8)]
        public int? WarningDataCount { get; set; }

        [DataMember]
        [JsonPropertyOrder(9)]
        public string? ErrorMessage { get; set; }

    }
}
