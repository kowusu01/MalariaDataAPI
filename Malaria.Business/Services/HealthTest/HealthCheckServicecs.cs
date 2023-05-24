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

                if (_dbContext.EnvInfos != null)
                {
                    envName = _dbContext.EnvInfos?.First().Name;
                }

                HealthCheckMessage testData = new HealthCheckMessage()
                {
                    Message = $"OK. {this.GetType().Name } sucessfully returned database environment { envName } from db.",
                    Timestamp = DateTime.Now.ToString()
                };

                return testData;
            }

        }

    }
}
