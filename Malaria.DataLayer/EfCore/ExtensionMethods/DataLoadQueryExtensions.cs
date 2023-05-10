using Common.Models.MalariaData;
using System;
using System.Collections.Generic;
using System.Linq;

using Common.Contants;
using Common.DataAccessParameters;

namespace EfCoreLayer.ExtensionMethods
{
    public static class DataLoadQueryExtensions
    {
        public static IQueryable<LoadStat> FilterBy(this IQueryable<LoadStat> dataLoadStats, DataAccessQueryParameters queryParameters)
        {
            if (string.IsNullOrEmpty(queryParameters.FilterByColumnValue))
                return dataLoadStats;

            switch (queryParameters.FilterByColumn)
            {
                case FilterByColumnEnum.no_filter:
                    return dataLoadStats;
                case FilterByColumnEnum.id:
                    int id = int.Parse(queryParameters.FilterByColumnValue);
                    return dataLoadStats.Where(x=>x.Id == id);
                case FilterByColumnEnum.load_timestamp:
                    var results = dataLoadStats;
                    try
                    {
                        var dt = DateTime.Parse(queryParameters.FilterByColumnValue).ToString("MM/dd/yyyy");
                        results = dataLoadStats.Where(x => x.LoadTimestamp.ToString("MM/dd/yyyy") == dt);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    return results;
                default:
                    return dataLoadStats;
            }
            
        }
    }
}
