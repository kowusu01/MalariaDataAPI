
using Microsoft.AspNetCore.Mvc;
using Common.Models.Malaria;

using Services.Queries;
using Common.ViewModels;

namespace MalariaDataAPI
{
    [Route("api/reported-data")]
    [ApiController]
    [Produces("application/json")]
    public class ReportedDataController : ControllerBase
    {
        private readonly ILogger<ReportedDataController> _logger;

        readonly IReportedDataQueryService _service;

        public ReportedDataController(ILogger<ReportedDataController> logger, IReportedDataQueryService service)
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

        [HttpGet("record_number/{record_number}")]
        public async Task<ActionResult<dynamic>> GetByRecordNumber(int record_number)
        {
            return await _service.GetByRecordNumber(record_number);
        }

        [HttpGet("load_date/{load_date}")]
        public async Task<ActionResult<dynamic>> GetByLoadDate(DateTime load_date)
        {
            return await _service.GetByLoadDate(load_date);
        }

        [HttpGet("filename/{filename}")]
        public async Task<ActionResult<dynamic>> GetByFileName(string fileName)
        {
            return await _service.GetByFileName(fileName);
        }

    }
}
