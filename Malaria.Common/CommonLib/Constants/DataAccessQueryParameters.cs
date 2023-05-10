
using Common.Contants;
namespace Common.DataAccessParameters
{
    public class DataAccessQueryParameters
    {
        public OrderByColumnEnum OrderByColumn { get; set; }
        public string? OrderByColumnValue { get; set; }

        public FilterByColumnEnum FilterByColumn { get; set; }
        public string? FilterByColumnValue { get; set; }

        public OrderBySchemeEnum OrderByScheme{ get;set; }
    }
    

}