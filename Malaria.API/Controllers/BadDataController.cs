

using Microsoft.AspNetCore.Mvc;
using Services.Queries;

namespace MalariaDataAPI
{
    [Route("api/bad-data")]
    [ApiController]
    [Produces("application/json")]
    public class BadDataController : ControllerBase
    {
        private readonly ILogger<BadDataController> _logger;

        readonly IBadDataQueryService _service;

        public BadDataController(ILogger<BadDataController> logger, IBadDataQueryService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// returns paginated list
        /// </summary>
        /// <returns></returns>

        [HttpGet("list")]
        public async Task<ActionResult<dynamic>> List()
        {
            return await _service.GetData();
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
