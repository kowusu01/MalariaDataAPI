using Common.Models.MalariaData;
using Common.ViewModels;


namespace Services.Queries
{
    public partial class ServicesHelper
    {
        public static dynamic MapListDataToViewModel(IEnumerable<dynamic> data)
        {
            return new ApiResultListViewModel()
            {
                meta = new ApiResultListMetaInfo()
                {
                    Location = "api/dataload/",
                    TotalRecords = data.Count(),
                    Page = 1,
                    PageSize = 1
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
