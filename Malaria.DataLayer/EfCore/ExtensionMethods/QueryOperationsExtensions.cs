using Common.Contants;
using Common.QueryParameters;

using Common.Models.Malaria;

namespace EfCore.ExtensionMethods
{
    public static class QueryOperationsExtensions
    {
        public static int SingleValueOperation(this IQueryable<ReportedData> efCoreData, DataQueryParameters queryParameters)
        {
            foreach ((DataFiltersNumeric op, MalariaDataColumns col, int value) qp in queryParameters.QueryComparisonNumeric)
            {
                switch (qp.op)
                {
                    case DataFiltersNumeric.eq:
                        efCoreData = efCoreData.NumericDataCompEqual(qp.col, qp.value);
                        break;
                    default:
                        return 0;
                }
            }

            foreach ((DataFiltersString op, MalariaDataColumns col, string value) qp in queryParameters.QueryComparisonString)
            {
                switch (qp.op)
                {
                    case DataFiltersString.eq:
                        efCoreData = efCoreData.StringDataCompEqual(qp.col, qp.value);
                        break;
                    default:
                        return 0;
                }
            }


            // now apply final op
            switch (queryParameters.QueryOp.op)
            {
                case SingleValuesOperations.sum:
                    return efCoreData.DataOperationSum(queryParameters.QueryOp.col);

                case SingleValuesOperations.count:
                    return efCoreData.DataOperationCount();

                case SingleValuesOperations.min:
                    return efCoreData.DataOperationMin(queryParameters.QueryOp.col);

                case SingleValuesOperations.max:
                    return efCoreData.DataOperationMax(queryParameters.QueryOp.col);
                default:
                    return 0;
            }

            return 0;

        }

        public static IQueryable<ReportedData> NumericDataCompEqual(this IQueryable<ReportedData> efCoreData, MalariaDataColumns col, int val)
        {
            switch(col)
            {
                case MalariaDataColumns.numCases:
                    return efCoreData.Where(x => x.NumCases == val);
                case MalariaDataColumns.numDeaths:
                    return efCoreData.Where(x => x.NumDeaths == val);
                case MalariaDataColumns.year:
                    return efCoreData.Where(x => x.Year == val);
                default:
                    return efCoreData;
            }
        }
        public static IQueryable<ReportedData> NumericDataCompGreaterThan(this IQueryable<ReportedData> efCoreData, MalariaDataColumns col, int val)
        {
            switch (col)
            {
                case MalariaDataColumns.numCases:
                    return efCoreData.Where(x => x.NumCases > val);
                case MalariaDataColumns.numDeaths:
                    return efCoreData.Where(x => x.NumDeaths > val);
                case MalariaDataColumns.year:
                    return efCoreData.Where(x => x.Year > val);
                default:
                    return efCoreData;
            }
        }

        public static IQueryable<ReportedData> StringDataCompEqual(this IQueryable<ReportedData> efCoreData, MalariaDataColumns col, string val)
        {
            switch (col)
            {
                case MalariaDataColumns.country:
                    return efCoreData.Where(x => x.Country.ToLower() == val.ToLower());
                case MalariaDataColumns.region:
                    return efCoreData.Where(x => x.Region.ToLower() == val.ToLower());

                default:
                    return efCoreData;
            }
        }
        public static int DataOperationSum(this IQueryable<ReportedData> efCoreData, MalariaDataColumns col)
        {
            switch (col)
            {
                case MalariaDataColumns.numCases:
                    return efCoreData.Sum(x => x.NumCases);
                    case MalariaDataColumns.numDeaths:
                    return efCoreData.Sum(x => x.NumDeaths);
                default:
                    return 0;
            }
        }
        public static int DataOperationCount(this IQueryable<ReportedData> efCoreData)
        {
            // this should be the last operation after filteringa dngrouping
            return efCoreData.Count();
        }
        public static int DataOperationMin(this IQueryable<ReportedData> efCoreData, MalariaDataColumns col)
        {
            // this should be the last operation after filteringa dngrouping
            switch (col)
            {
                case MalariaDataColumns.numCases:
                    return efCoreData.Min(x => x.NumCases);
                case MalariaDataColumns.numDeaths:
                    return efCoreData.Min(x => x.NumDeaths);
                case MalariaDataColumns.year:
                    return efCoreData.Min(x => x.Year);
                default:
                    return 0;
            }
        }
        public static int DataOperationMax(this IQueryable<ReportedData> efCoreData, MalariaDataColumns col)
        {
            // this should be the last operation after filteringa dngrouping
            switch (col)
            {
                case MalariaDataColumns.numCases:
                    return efCoreData.Max(x => x.NumCases);
                case MalariaDataColumns.numDeaths:
                    return efCoreData.Max(x => x.NumDeaths);
                case MalariaDataColumns.year:
                    return efCoreData.Max(x => x.Year);
                default:
                    return 0;
            }
        }
    }
}
