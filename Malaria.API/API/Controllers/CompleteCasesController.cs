
using Microsoft.AspNetCore.Mvc;
using Common.Models.MalariaData;

using Services.Queries;
using Common.ViewModels;

namespace MalariaDataAPI
{
    [Route("api/complete-data")]
    [ApiController]
    [Produces("application/json")]
    public class CompleteCasesController : ControllerBase
    {
        private readonly ILogger<CompleteCasesController> _logger;

        readonly ICompleteDataQueryService _service;

        public CompleteCasesController(ILogger<CompleteCasesController> logger, ICompleteDataQueryService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// returns paginated list
        /// </summary>
        /// <returns></returns>

        [HttpGet("list")]
        public async Task<ActionResult<dynamic>> GetCompleteData()
        {
            return await _service.GetCompleteData();
        }

        [HttpGet("load_id/{id}")]
        public async Task<ActionResult<dynamic>> GetCompleteDataById(int id)
        {
            return await _service.GetCompleteDataById(id);
        }


        [HttpGet("load_date/{load_date}")]
        public async Task<ActionResult<dynamic>> GetCompleteDataByLoadDate(DateTime load_date)
        {
            return await _service.GetCompleteDataByDate(load_date);
        }

        [HttpGet("filename/{filename}")]
        public async Task<ActionResult<dynamic>> GetCompleteDataByFileName(string fileName)
        {
            return await _service.GetCompleteDataByFileName(fileName);
        }




    }
}
