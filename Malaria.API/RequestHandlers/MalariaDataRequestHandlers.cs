using Microsoft.AspNetCore.Mvc;
using Services.Queries;
using Common.QueryParameters;

namespace WorldInfo.API.RequestHandlers
{
    public class Explore
    {
        private readonly ILogger _logger;
        readonly IQueryOperationsServiceInterface _service;

        public int DefaultPageSize { get; set; }
        public int MaxPageSize { get; set; }

        public Explore(ILogger logger,
             IQueryOperationsServiceInterface service, 
            int defaultPageSize,
            int maxPageSize=1000)
        {
            _logger = logger;
            _service = service;
            DefaultPageSize = defaultPageSize;
            MaxPageSize = maxPageSize;
        }
        
        public async Task<dynamic> Sum(
            [FromQuery(Name = "col")] string col, // only required field 
            [FromQuery(Name = "filterNumericCol")] string? numericFilterCol,
            [FromQuery(Name = "filterNumericOp")] string? numericFilterOp,
            [FromQuery(Name = "filterNumericValue")] int? numericFilterValue,

            [FromQuery(Name = "filterStringCol")] string? stringFilterCol,
            [FromQuery(Name = "filterStringOp")] string? stringFilterOp,
            [FromQuery(Name = "filterStringValue")] string? stringFilterValue
            )
        {
            return await _service.ExecutSingleValueQuery("sum", col, 
                numericFilterCol, numericFilterOp, numericFilterValue,
                stringFilterCol, stringFilterOp, stringFilterValue);
        }

        public async Task<dynamic> Count(
            [FromQuery(Name = "filterNumericCol")] string? numericFilterCol,
            [FromQuery(Name = "filterNumericOp")] string? numericFilterOp,
            [FromQuery(Name = "filterNumericValue")] int? numericFilterValue,

            [FromQuery(Name = "filterStringCol")] string? stringFilterCol,
            [FromQuery(Name = "filterStringOp")] string? stringFilterOp,
            [FromQuery(Name = "filterStringValue")] string? stringFilterValue
            )
        {
            return await _service.ExecutSingleValueQuery("count", "none",
                numericFilterCol, numericFilterOp, numericFilterValue,
                stringFilterCol, stringFilterOp, stringFilterValue);
        }

        public async Task<dynamic> Min(
            [FromQuery(Name = "col")] string col // only required field
            )
        {
            return await _service.ExecutSingleValueQuery("min", col);
        }

        public async Task<dynamic> Max(
            [FromQuery(Name = "col")] string col // only required field
            )
        {
            return await _service.ExecutSingleValueQuery("max",col);
        }





    }
}
