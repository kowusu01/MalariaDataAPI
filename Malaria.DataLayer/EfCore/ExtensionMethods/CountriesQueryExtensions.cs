
using Common.Contants;
using Common.QueryParameters;
using Common.Models.WorldInfo;

namespace EfCoreLayer.ExtensionMethods
{
    public static partial class QueryExtensions
    {
        public static IQueryable<Country> FilterCountriesSetBy(this IQueryable<Country> efCoreData, QueryParameters queryParameters)
        {

            if (string.IsNullOrEmpty(queryParameters.FilterByColumnValue))
                return efCoreData;

            switch (queryParameters.FilterByColumn)
            {
                case FilterByColumnEnum.NoFiltering:
                    return efCoreData;

                case FilterByColumnEnum.Id:
                    int id = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.Id == id);

                case FilterByColumnEnum.RegionCode:
                    return efCoreData.Where(x => x.WHORegionCode.Equals(queryParameters.FilterByColumnValue, StringComparison.InvariantCultureIgnoreCase)); ;

                case FilterByColumnEnum.ISONum:
                    return efCoreData.Where(x => x.ISONum == queryParameters.FilterByColumnValue);

                default:
                    return efCoreData;
            }
        }
        public static IQueryable<Country> LimitBy(this IQueryable<Country> efCoreData, QueryParameters queryParameters)
        {
            int previous = 0;
            int count = efCoreData.Count();
            if (queryParameters.PaginationInfo.Page > 1)
            {
                previous = (queryParameters.PaginationInfo.Page - 1) * queryParameters.PaginationInfo.PageSize;
                if (count > previous)
                {
                    if ((count-previous) > queryParameters.PaginationInfo.PageSize)
                    {
                        return efCoreData.Skip(previous).Take(queryParameters.PaginationInfo.PageSize);
                    }
                    else
                    {
                        return efCoreData.Skip(previous).Take((count-previous));
                    }
                }
                else
                {
                    int take  = Math.Min(count, queryParameters.PaginationInfo.PageSize);
                    return efCoreData.Take(take);
                }


            }
            else
            {
                if ( count > queryParameters.PaginationInfo.PageSize)
                {
                    return efCoreData.Take(queryParameters.PaginationInfo.PageSize);
                }
                else
                    return efCoreData;
            }
        }
    }
}
