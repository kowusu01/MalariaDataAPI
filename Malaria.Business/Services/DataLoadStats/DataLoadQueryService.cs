

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Common.Models.MalariaData;
using Common.Contants;
using Common.ViewModels;
using Common.DataAccessParameters;

using EfCoreLayer;
using Business.QueryTasks;

namespace Services.Queries
{
    public class DataLoadQueryService : IDataLoadQueryService
    {
        private readonly ILogger<DataLoadQueryService> _logger;
        
        //private readonly AppDbContext _dbContext;

        // this service has only one task runner, DataLoadStatsTaskRUnner
        private readonly  IDataLoadQueryTaskRunner _taskRunner;

        public DataLoadQueryService(ILogger<DataLoadQueryService> logger, IDataLoadQueryTaskRunner runnerObj)
        {
            _logger = logger;
        //    _dbContext = dbContext;
            _taskRunner = runnerObj;
        }

        public async Task<IEnumerable<LoadStat>> GetLoadStats()
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return
             
             return await _taskRunner.RunTasks(new DataAccessQueryParameters());
        }
    }
}