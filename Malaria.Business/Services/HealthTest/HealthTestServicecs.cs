using Common.Services;
using Common.ViewModels;
using EfCoreLayer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QueryServices.HealthTest.HealthTestServicecs;

namespace QueryServices.HealthTest
{
    public class HealthTestServicecs
    {
        public class HealthTestService : AbstractHealthTestService
        {
            readonly ILogger<HealthTestService> _logger;
            AppDbContext _dbContext;

            public HealthTestService(ILogger<HealthTestService> logger, AppDbContext dbContext)
            {
                _logger = logger;
                _dbContext = dbContext;
            }

            public override HealthTestMessage GetDbTestString()
            {
                string? envName = string.Empty;

                if (_dbContext.EnvInfos != null)
                {
                    envName = _dbContext.EnvInfos?.First().Name;
                }

                HealthTestMessage testData = new HealthTestMessage()
                {
                    Message = $"OK. {this.GetType().Name } sucessfully returned database environment { envName } from db.",
                    Timestamp = DateTime.Now.ToString()
                };

                return testData;
            }

        }

    }
}
