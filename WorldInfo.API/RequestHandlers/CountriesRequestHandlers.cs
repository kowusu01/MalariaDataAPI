using Microsoft.AspNetCore.Mvc;
using Services.Queries;

namespace WorldInfo.API.RequestHandlers
{
    public class CountriesRequestHandlers
    {
        private readonly ILogger _logger;
        readonly ICountriesQueryService _service;

        public int DefaultPageSize { get; set; }
        public int MaxPageSize { get; set; }

        public CountriesRequestHandlers(ILogger logger,
            ICountriesQueryService service, 
            int defaultPageSize,
            int maxPageSize=100)
        {
            _logger = logger;
            _service = service;
            DefaultPageSize = defaultPageSize;
            MaxPageSize = maxPageSize;
        }
        
        public async Task<ActionResult<dynamic>> List(
            [FromQuery(Name = "page")] int? page, /* page number in a paginated list, e.g. 2 */
            [FromQuery(Name = "pageSize")] int? pageSize /* page size in a paginated list, e.g. 10 */
            )
        {
            return await _service.List(page, pageSize, DefaultPageSize);
        }
        public async Task<ActionResult<dynamic>> GetCountriesBy(

            [FromQuery(Name = "id")] int? id,           /* the unique country id */
            [FromQuery(Name = "name")] string? name,    /* partial or full country name, e.g.  "Ghana" or "People Republic of" */
            [FromQuery(Name = "regionCode")] string? regionCode,    /* WHO region code. e.g AFR for Africa  */
            [FromQuery(Name = "iso2")] string? iso2Digits,    /* 2-digit iso code, e.g. "gh" */
            [FromQuery(Name = "iso3")] string? iso3Digits,    /* 3-digit iso code, e.g. "gha" */
            [FromQuery(Name = "isoNum")] string? isoNumber,  /* e.g. "288" */

            [FromQuery(Name = "page")] int? page, /* page number in a paginated list, e.g. 2 */
            [FromQuery(Name = "pageSize")] int? pageSize /* page size in a paginated list, e.g. 10 */

            )
        {
            page =  (page !=null && page > 0) ? page : 1;
            pageSize = (pageSize != null && pageSize > 0 ) ? pageSize : DefaultPageSize;
            pageSize = (pageSize > 0 && pageSize < MaxPageSize + 1) ? pageSize : MaxPageSize;

            if (id!=null)
                return await _service.GetById(id.Value);  //  no pagination required
            if (name!=null)
                return await _service.GetByCountryName(name, page, pageSize);  
            if (regionCode != null)
                return await _service.GetByRegionCode(regionCode, page, pageSize);  
            if (iso2Digits!=null)
                return await _service.GetByISO2(iso2Digits);
            if (iso3Digits!=null)
                return await _service.GetByISO3(iso3Digits);
            if (isoNumber != null)
                return await _service.GetByISONumber(isoNumber);
            else
                return await _service.List(page, pageSize);

        }
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            return await _service.GetById(id);
        }
       
        public async Task<ActionResult<dynamic>> GetByRegionName(string regionName, int? page, int? pageSize)
        {
            page = (page != null && page > 0) ? page : 1;
            pageSize = (pageSize != null && pageSize > 0) ? pageSize : DefaultPageSize;
            pageSize = (pageSize > 0 && pageSize < MaxPageSize + 1) ? pageSize : MaxPageSize;

            return await _service.GetByRegionName(regionName, page, pageSize);
        }

        public async Task<ActionResult<dynamic>> GetByRegionCode(string regionCode, int? page, int? pageSize)
        {
            page = (page != null && page > 0) ? page : 1;
            pageSize = (pageSize != null && pageSize > 0) ? pageSize : DefaultPageSize;
            pageSize = (pageSize > 0 && pageSize < MaxPageSize + 1) ? pageSize : MaxPageSize;

            return await _service.GetByRegionCode(regionCode, page, pageSize);
        }
    }
}
