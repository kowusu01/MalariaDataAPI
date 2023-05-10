using System.Text.Json.Serialization;
using Common.Models;

namespace CommonLib.ViewModels
{
    public class ApiResultMetaInfo
    {
        [JsonPropertyOrder(0)]
        public string Location { get; set; }
    }

    public class ApiResultListMetaInfo : ApiResultMetaInfo
    {
        [JsonPropertyOrder(1)]
        public int TotalRecords { get; set; }

        [JsonPropertyOrder(2)]
        public int Page { get; set; } = 1;

        [JsonPropertyOrder(3)]
        public int PageSize { get; set; }
    }
}
