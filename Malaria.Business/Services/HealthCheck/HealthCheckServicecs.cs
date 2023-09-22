using Common.Services;
using Common.ViewModels;
using EfCoreLayer.MalariaData;
using EfCoreLayer.WorldInfo;
using Microsoft.Extensions.Logging;

namespace Services.HealthCheck
{
    public class HealthCheckServicecs
    {
        public class HealthCheckService<T> : AbstractHealthCheckService where T : AppDbContext
        {
            readonly ILogger<HealthCheckService<T>> _logger;
            T _dbContext;

            public HealthCheckService(ILogger<HealthCheckService<T>> logger, T dbContext)
            {
                _logger = logger;
                _dbContext = dbContext;
            }

            public override HealthCheckMessage PerformDbHealthCheck()
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
