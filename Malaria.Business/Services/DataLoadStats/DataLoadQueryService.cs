

using Microsoft.Extensions.Logging;

using Common.Models.MalariaData;
using Common.Contants;
using Common.DataAccessParameters;

using Business.QueryTasks;
using Common.ViewModels;

namespace Services.Queries
{

    public interface IDataLoadQueryService
    {
        Task<dynamic> GetLoadStats();
        Task<dynamic> GetLoadStatsById(int id);
        Task<dynamic> GetLoadStatsByDate(DateTime date);
    }


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

        public async Task<dynamic> GetLoadStats()
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return
             
            var data  =  await _taskRunner.RunTasks(new DataAccessQueryParameters());
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetLoadStatsById(int id)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.Id, FilterByColumnValue = id.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetLoadStatsByDate(DateTime loadDate)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.LoadTimestamp, FilterByColumnValue = loadDate.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }

        

    }
}