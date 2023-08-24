using Common.Services;
using Common.ViewModels;
using EfCoreLayer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QueryServices.HealthTest.HealthCheckServicecs;

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
                string? envName = string.Empty;

                HealthCheckMessage testData = new HealthCheckMessage()
                {
                    Message = $"OK. {this.GetType().Name } -  sucessfully connected to db in environment {_dbContext.EnvInfos?.First().Name}. " +
                    $"{_dbContext.EnvInfos?.First().Descr}",
                    Timestamp = DateTime.Now.ToString()
                };

                return testData;
            }

        }

    }
}
