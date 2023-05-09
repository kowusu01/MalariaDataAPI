
using System.Text.Json.Serialization;
using Common.Models.StudentsPrototype;

namespace Common.StudentsPrototype.ViewModels
{
    public partial class StudentList
    {
        public ApiListMetaInfo Meta { get; set; }
        public IEnumerable<DataLoadStats> Students { get; set; }
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