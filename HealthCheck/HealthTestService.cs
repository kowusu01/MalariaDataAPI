
using Microsoft.Extensions.Logging;

using Common.Data.EfCore;
using Common.ViewModels;

namespace Common.Services
{
    public class TestService : ITestService
    {
        readonly ILogger<TestService> _logger;
        AppDbContext _dbContext;

        public TestService(ILogger<TestService> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public HealthTestMessage GetDbTestString()
        {
            string? envName = string.Empty;

            if (_dbContext.DBEnvironmentInfo != null)
            {
                envName = _dbContext.DBEnvironmentInfo?.First().ID;
            }

            HealthTestMessage testData = new HealthTestMessage()
            {
                Message = "Hello from Common.Services layer with Db access. Database environment: " + envName,
                Timestamp = DateTime.Now.ToString()
            };

            return testData;
        }

    }

}