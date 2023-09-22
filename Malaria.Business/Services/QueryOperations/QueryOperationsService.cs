
using BusinessQueries.TaskRunners.WorldInfo;
using Common.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Services.Queries
{
    public interface IQueryOperationsServiceInterface
    {
        Task<dynamic> ExecutSingleValueQuery(string op);
        Task<dynamic> ExecutSingleValueQuery(string op, string col,
            string? filterColNumeric = null,
            string? filterOpNumeric = null,
            int? filterValueNumeric = null,

            string? filterColString = null,
            string? filterOpString = null,
            string? filterValueString = null);
        //Task<dynamic> GetByRegionCode(string regionCode, int? page, int? pageSize, int defaultPageSize = 10);
        //Task<dynamic> GetByISONumber(string isoNumber);
    }


    public class QueryOperationsService : IQueryOperationsServiceInterface
    {
        private readonly ILogger<QueryOperationsService> _logger;
        private readonly IQueryOperationsTaskRunner _taskRunner;

        public QueryOperationsService(ILogger<QueryOperationsService> logger, IQueryOperationsTaskRunner runnerObj)
        {
            _logger = logger;
            _taskRunner = runnerObj;
        }

        public Task<dynamic> ExecutSingleValueQuery(string op)
        {
            return ExecutSingleValueQuery(op, "none");
        }
        public Task<dynamic> ExecutSingleValueQuery(string op, string col,
            string? filterNumericCol = null, // qty
            string? filterNumericOp = null,  // greaterThan
            int? filterNumericValue = null,  // e.g: 0
            string? filterStringCol = null, // e.g. country
            string? filterStringOp = null,  // e.g. equal
            string? filterStringValue = null) // e.g. ghana
        {
            try
            {
                SingleValuesOperations selectecOp = (SingleValuesOperations)Enum.Parse(typeof(SingleValuesOperations), op, true);
                MalariaDataColumns selectedCol = selectedCol = (MalariaDataColumns)Enum.Parse(typeof(MalariaDataColumns), col, true);

                DataQueryParameters dataQueryParameters = new DataQueryParameters();

                //1. check and add numeric filters
                if (filterNumericOp!=null)
                {
                    DataFiltersNumeric numericFilterOp = (DataFiltersNumeric)Enum.Parse(typeof(DataFiltersNumeric), filterNumericOp, true);
                    MalariaDataColumns numericFilterColumn = (MalariaDataColumns)Enum.Parse(typeof(MalariaDataColumns), filterNumericCol, true);
                    (DataFiltersNumeric op, MalariaDataColumns col, int value) numericFilter = (numericFilterOp, numericFilterColumn, filterNumericValue.Value);
                    dataQueryParameters.QueryComparisonNumeric.Add(numericFilter);
                }

                //2. check and add string filters
                if (filterStringOp != null)
                {
                    DataFiltersString numericFilterOp = (DataFiltersString)Enum.Parse(typeof(DataFiltersString), filterStringOp, true);
                    MalariaDataColumns numericFilterColumn = (MalariaDataColumns)Enum.Parse(typeof(MalariaDataColumns), filterStringCol, true);
                    (DataFiltersString op, MalariaDataColumns col, string value) stringFilter = (numericFilterOp, numericFilterColumn, filterStringValue);
                    dataQueryParameters.QueryComparisonString.Add(stringFilter);
                }

                // 3. add the final op e.g. sum
                dataQueryParameters.QueryOp = (selectecOp, selectedCol);
                return _taskRunner.RunSingleValueTasks(dataQueryParameters);
            }
            catch (Exception e) { }

            return null;

        }
    }
}
