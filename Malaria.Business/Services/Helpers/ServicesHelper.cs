using Common.Models.Malaria;
using Common.ViewModels;


namespace Services.Queries
{
    public partial class ServicesHelper
    {
        public static dynamic MapListDataToViewModel(IEnumerable<dynamic> data, int page=1, int pageSize=1000)
        {
            return new ApiResultListViewModel()
            {
                meta = new ApiResultListMetaInfo()
                {
                    Location = "api/dataload/",
                    TotalRecords = data.Count(),
                    Page = page,
                    PageSize = pageSize
                },
                data = data
            };
        }

        public static dynamic MapDataToViewModel(dynamic data)
        {
            return new ApiResultSingleItemViewModel()
            {
                meta = new ApiResultMetaInfo()
                {
                    Location = "api/dataload/",
                },
                data = data
            };
        }

    }
}
