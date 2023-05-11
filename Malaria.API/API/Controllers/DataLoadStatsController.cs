
using Microsoft.AspNetCore.Mvc;
using Common.Models.MalariaData;

using Services.Queries;
using Common.ViewModels;

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
            return await _service.GetLoadStats();
        }
        
        [HttpGet("load_id/{id}")]
        public async Task<ActionResult<dynamic>> GetDataLoadStatsById(int id)
        {
            return await _service.GetLoadStatsById(id);
        }
        

        [HttpGet("load_date/{load_date}")]
        public async Task<ActionResult<dynamic>> GetDataLoadStatsByDate(DateTime load_date)
        {
            return await _service.GetLoadStatsByDate(load_date);
        }
        


    }
}
