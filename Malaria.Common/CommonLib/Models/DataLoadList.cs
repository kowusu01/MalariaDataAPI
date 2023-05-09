
using System.Text.Json.Serialization;
using Common.Models.MalariaData;

namespace Common.Models.MalariaData
{
    public partial class DataLoadList
    {
        public ApiListMetaInfo Meta { get; set; }
        public IEnumerable<LoadStat> DataLoads { get; set; }
    }

    public class ApiMetaInfo
    {
        [JsonPropertyOrder(0)]
        public string Location { get; set; }
    }

    public class ApiListMetaInfo : ApiMetaInfo
    {
        [JsonPropertyOrder(1)]
        public int TotalRecords { get; set; }

        [JsonPropertyOrder(2)]
        public int Page { get; set; } = 1;

        [JsonPropertyOrder(3)]
        public int PageSize { get; set; }
    }

}