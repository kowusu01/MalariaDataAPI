using Common.Services;
using Common.ViewModels;
using EfCoreLayer.MalariaData;
using Microsoft.Extensions.Logging;


//using static QueryServices.HealthTest.HealthCheckServicecs;

namespace QueryServices.HealthTest
{
    public class HealthCheckServicecs
    {
        public class HealthTestService : AbstractHealthCheckService
        {
            readonly ILogger<HealthTestService> _logger;
            AppDbContext _dbContext;

            public HealthTestService(ILogger<HealthTestService> logger, AppDbContext dbContext)
            {
                _logger = logger;
                _dbContext = dbContext;
            }

            public override HealthCheckMessage GetDbTestString()
            {

                string message = $"OK. { this.GetType().Name } - Successfully connected to database but no environment information was available in the db.";

                if (_dbContext.EnvInfos?.Count() > 0)
                {
                    message = $"OK. {this.GetType().Name} -  sucessfully connected to db in environment " +
                    $"{_dbContext.EnvInfos?.First().Name}. " +
                    $"{_dbContext.EnvInfos?.First().Descr}";
                }

                return new HealthCheckMessage()
                {
                    Message = message,
                    Timestamp = DateTime.Now.ToString()
                }; ;
            }

        }

    }
}
