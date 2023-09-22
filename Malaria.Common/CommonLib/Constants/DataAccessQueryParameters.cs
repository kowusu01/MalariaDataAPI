
using Common.Contants;
namespace Common.QueryParameters
{
    public class QueryParameters
    {
        public QueryParameters()
        {
            PaginationInfo.Page = 1;
            PaginationInfo.PageSize = 1000;
        }
        public OrderByColumnEnum OrderByColumn { get; set; }
        public string? OrderByColumnValue { get; set; }

        public FilterByColumnEnum FilterByColumn { get; set; }
        public string? FilterByColumnValue { get; set; }

        public OrderBySchemeEnum OrderByScheme{ get;set; }

        ListPagination _pagination = new ListPagination();

        public ListPagination PaginationInfo {
            get { return _pagination; } set { _pagination = value; } }
    }
 }