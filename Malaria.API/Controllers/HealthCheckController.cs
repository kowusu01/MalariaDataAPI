
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.HealthCheck;
using QueryServices.Interfaces;

namespace MalariaDataAPI
{
    [Route("api/health-check")]
    [ApiController]
    [Produces("application/json")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;
        IHealthCheckInterface _testService;

        public HealthCheckController(ILogger<HealthCheckController> logger, IHealthCheckInterface service)
        {
            _logger = logger;
            _testService = service;
        }

        /// <summary>
        /// Basic health test to check if service is running. No db access is attempted.
        /// </summary>
        /// <returns></returns>
        [HttpGet("basic")]
        public HealthCheckMessage BasicTest()
        {
            _logger.LogInformation($"Basic health test: {_testService.PerformBasicHeatlthCheck().Message} - {_testService.PerformBasicHeatlthCheck().Timestamp}");
            
            return new HealthCheckMessage { Message = _testService.PerformBasicHeatlthCheck().Message,
                Timestamp = _testService.PerformBasicHeatlthCheck().Timestamp
            };
        }

        /// <summary>
        /// Health check with db access to make sure app is connected to db. It attempts to return basic information from db.
        /// </summary>
        /// <returns></returns>
        [HttpGet("db")]
        public HealthCheckMessage DBTest()
        {
            HealthCheckMessage testMessage = _testService.PerformDbHealthCheck();
            _logger.LogInformation(string.Format("{0} - {1}", testMessage.Message, testMessage.Timestamp));
            return testMessage;
        }

    }

}