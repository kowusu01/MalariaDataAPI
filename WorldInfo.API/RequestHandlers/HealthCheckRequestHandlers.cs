using Common.ViewModels;
using QueryServices.Interfaces;

namespace WorldInfo.API.RequestHandlers
{
    public class HealthCheck
    {
        private readonly ILogger _logger;
        IHealthCheckInterface _healthCheckService;

        public HealthCheck(ILogger logger, IHealthCheckInterface service)
        {
            _logger = logger;
            _healthCheckService = service;
        }

        public HealthCheckMessage BasicTest()
        {
            _logger.LogInformation($"Basic health test: {_healthCheckService.PerformBasicHeatlthCheck().Message} - {_healthCheckService.PerformBasicHeatlthCheck().Timestamp}");

            return new HealthCheckMessage
            {
                Message = _healthCheckService.PerformBasicHeatlthCheck().Message,
                Timestamp = _healthCheckService.PerformBasicHeatlthCheck().Timestamp
            };
        }

        public HealthCheckMessage DBTest()
        {
            HealthCheckMessage testMessage = _healthCheckService.PerformDbHealthCheck();
            _logger.LogInformation(string.Format("{0} - {1}", testMessage.Message, testMessage.Timestamp));
            return testMessage;
        }
    }
}
