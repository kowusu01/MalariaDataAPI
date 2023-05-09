
using Microsoft.AspNetCore.Mvc;
using Common.Models.MalariaData;

using Services.Queries;

namespace MalariaDataAPI
{
    [Route("api/dataload")]
    [ApiController]
    [Produces("application/json")]
    public class DataLoadStatatsController : ControllerBase
    {
        private readonly ILogger<DataLoadStatatsController> _logger;

        readonly IDataLoadQueryService _service;

        public DataLoadStatatsController(ILogger<DataLoadStatatsController> logger, IDataLoadQueryService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// returns paginated list
        /// </summary>
        /// <returns></returns>

        [HttpGet("list")]
        public async Task<ActionResult<dynamic>> GetDataLoadStats()
        {
            _logger.LogInformation("DataLoadStatatsController.GetDataLoadStats()...");

            var dataLoads =  await _service.GetLoadStats();

            if (dataLoads == null)
            {
                _logger.LogInformation("DataLoadStatatsController.GetDataLoadStats() - _context.LoadStats is null.");
                return NotFound();
            }

            _logger.LogInformation("DataLoadStatatsController.GetDataLoadStats() - returning {0} out of {1} dataloads.", dataLoads.Count(), dataLoads.Count());

            return new DataLoadList()
            {
                Meta = new ApiListMetaInfo()
                {
                    Location = "api/dataload/",
                    TotalRecords = dataLoads.Count(),
                    Page = 1,
                    PageSize = 1
                },
                DataLoads = dataLoads
            };
        }



    }
}
