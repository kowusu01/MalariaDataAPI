
using Common.Contants;
using Common.Models;
using Common.Models.Malaria;
using Common.QueryParameters;

namespace EfCoreLayer.ExtensionMethods
{
    public static partial class QueryExtensions
    {
        public static IQueryable<LoadStat>  FilterDataLoadStatsSetBy(this IQueryable<LoadStat> efCoreData, QueryParameters queryParameters)
        {

            if (string.IsNullOrEmpty(queryParameters.FilterByColumnValue))
                return efCoreData;

            switch (queryParameters.FilterByColumn)
            {
                case FilterByColumnEnum.NoFiltering:
                    return efCoreData;

                case FilterByColumnEnum.Id:
                    int id = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x=>x.Id == id);

                case FilterByColumnEnum.Status:
                    return efCoreData.Where(x => x.LoadStatus.ToLower()==queryParameters.FilterByColumnValue.ToLower());

                case FilterByColumnEnum.LoadTimestamp:
                    var results = efCoreData;
                    try
                    {
                        var dt = DateTime.Parse(queryParameters.FilterByColumnValue).ToString("MM/dd/yyyy");
                        results = efCoreData.Where(x => x.LoadTimestamp.ToString("MM/dd/yyyy") == dt);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    return results;
                default:
                    return efCoreData;
            }
        }

        public static IQueryable<CasesReportedBad> FilterBadDataSetBy(this IQueryable<CasesReportedBad> efCoreData, QueryParameters queryParameters)
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

                case FilterByColumnEnum.LoadId:
                    int loadId = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.LoadId == loadId);

                case FilterByColumnEnum.RecordNumber:
                    int paramValue = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.RecordNumber == paramValue);
                
                case FilterByColumnEnum.LoadTimestamp:
                    var results = efCoreData;
                    try
                    {
                        var dt = DateTime.Parse(queryParameters.FilterByColumnValue).ToString("MM/dd/yyyy");
                        results = efCoreData.Where(x => x.Load.LoadTimestamp.ToString("MM/dd/yyyy") == dt);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    return results;
                
                default:
                    return efCoreData;
            }
        }

        public static IQueryable<ReportedData> FilterReportedDataSetBy(this IQueryable<ReportedData> efCoreData, QueryParameters queryParameters)
        {
            /*var groupedValues = efCoreData.GroupBy(
                x => x.Country, x => x.NumDeaths
                ).Sum(x => x.Key);
    

            foreach(var group in groupedValues)
            {
                Console.WriteLine($"Key: {group.Key} - Value: {group.}");
            }        */

            if (string.IsNullOrEmpty(queryParameters.FilterByColumnValue))
                return efCoreData;

            switch (queryParameters.FilterByColumn)
            {
                case FilterByColumnEnum.NoFiltering:
                    return efCoreData;

                case FilterByColumnEnum.Id:
                    int id = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.Id == id);

                case FilterByColumnEnum.LoadId:
                    int loadId = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.LoadId == loadId);

                case FilterByColumnEnum.RecordNumber:
                    int paramValue = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.RecordNumber == paramValue);
                
                case FilterByColumnEnum.LoadTimestamp:
                    var results = efCoreData;
                    try
                    {
                        var dt = DateTime.Parse(queryParameters.FilterByColumnValue).ToString("MM/dd/yyyy");
                        results = efCoreData.Where(x => x.Load.LoadTimestamp.ToString("MM/dd/yyyy") == dt);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    return results;
                
                default:
                    return efCoreData;
            }
        }

        public static IQueryable<DataIssuesDetail> FilterDataIssuesSetBy(this IQueryable<DataIssuesDetail> efCoreData, QueryParameters queryParameters)
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

                case FilterByColumnEnum.LoadId:
                    int loadId = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.LoadId == loadId);

                case FilterByColumnEnum.RecordNumber:
                    int paramValue = int.Parse(queryParameters.FilterByColumnValue);
                    return efCoreData.Where(x => x.RecordNumber == paramValue);

                case FilterByColumnEnum.IssueType:
                    return efCoreData.Where(x => x.IssueType.ToLower() == queryParameters.FilterByColumnValue.ToLower());

                case FilterByColumnEnum.FilePath:
                    return efCoreData.Where(x => x.Load.FilePath == queryParameters.FilterByColumnValue);

                case FilterByColumnEnum.LoadTimestamp:
                    var results = efCoreData;
                    try
                    {
                        var dt = DateTime.Parse(queryParameters.FilterByColumnValue).ToString("MM/dd/yyyy");
                        results = efCoreData.Where(x => x.Load.LoadTimestamp.ToString("MM/dd/yyyy") == dt);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    return results;

                default:
                    return efCoreData;
            }
        }

    }
}
