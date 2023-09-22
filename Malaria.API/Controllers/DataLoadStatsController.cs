
using Microsoft.AspNetCore.Mvc;
using Common.Models.Malaria;

using Services.Queries;
using Common.ViewModels;

namespace MalariaDataAPI
{
    [Route("api/dataload")]
    [ApiController]
    [Produces("application/json")]
    public class DataLoadStatsController : ControllerBase
    {
        private readonly ILogger<DataLoadStatsController> _logger;

        readonly IDataLoadQueryService _service;

        public DataLoadStatsController(ILogger<DataLoadStatsController> logger, IDataLoadQueryService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("list")]
        public async Task<ActionResult<dynamic>> List(
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "pageSize")] int? pageSize
            )
        {
            return await _service.List(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            return await _service.GetById(id);
        }
        [HttpGet("load_id/{load_id}")]
        public async Task<ActionResult<dynamic>> GetByLoadId(int load_id)
        {
            return await _service.GetByLoadId(load_id);
        }

        [HttpGet("load_date/{load_date}")]
        public async Task<ActionResult<dynamic>> GetByDate(DateTime load_date)
        {
            return await _service.GetByLoadDate(load_date);
        }


        [HttpGet("status/{status}")]
        public async Task<ActionResult<dynamic>> GetByStatus(string status)
        {
            return await _service.GetByLoadStatus(status);
        }


    }
}
