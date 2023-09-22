using Common.ViewModels;
using EfCoreLayer.WorldInfo;
using Microsoft.Extensions.Logging;
using QueryServices.Interfaces;

namespace Services.HealthCheck
{
    public class WorldInfoApiHealthCheckService : AbstractHealthCheckService
    {
        readonly ILogger<WorldInfoApiHealthCheckService> _logger;
        WorlInfoApiDbContext _dbContext;

        public WorldInfoApiHealthCheckService(ILogger<WorldInfoApiHealthCheckService> logger, WorlInfoApiDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public override HealthCheckMessage PerformDbHealthCheck()
        {

            string message = $"OK. {this.GetType().Name} - Successfully connected to database but no environment information was available in the db.";

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
