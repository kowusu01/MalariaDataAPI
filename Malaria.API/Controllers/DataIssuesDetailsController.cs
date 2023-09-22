
using Microsoft.AspNetCore.Mvc;
using Common.Models.Malaria;

using Services.Queries;
using Common.ViewModels;

namespace MalariaDataAPI
{
    [Route("api/data-issues")]
    [ApiController]
    [Produces("application/json")]
    public class DataIssuesController : ControllerBase
    {
        private readonly ILogger<DataIssuesController> _logger;

        readonly IDataIssuesDetailsQueryService _service;

        public DataIssuesController(ILogger<DataIssuesController> logger, IDataIssuesDetailsQueryService service)
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
        [HttpGet("issue_type/{issue_type}")]
        public async Task<ActionResult<dynamic>> GetByIssueType(string issue_type)
        {
            return await _service.GetByIssueType(issue_type);
        }
        [HttpGet("filename/{filename}")]
        public async Task<ActionResult<dynamic>> GetByFileName(string filename)
        {
            return await _service.GetByFileName(filename);
        }

    }
}
