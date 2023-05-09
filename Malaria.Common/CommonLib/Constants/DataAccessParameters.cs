
using Common.Contants;
namespace Common.DataAccessParameters
{
    public class DataAccessQueryParameters
    {
        public List<OrderByColumnsEnum> OrderByColumnList { get; set; }
        public List<FilterByColumnsEnum> FilterByColumnList { get; set; }
        public OrderBySchemeEnum OrderByScheme{ get;set; }
    }
    

}