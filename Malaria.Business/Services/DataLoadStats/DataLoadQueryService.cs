

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Common.Models.MalariaData;
using Common.Contants;
using Common.ViewModels;
using Common.DataAccessParameters;

using EfCoreLayer;
using Business.QueryTasks;
using CommonLib.ViewModels;

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

        public async Task<dynamic> GetLoadStats()
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return
             
            var data  =  await _taskRunner.RunTasks(new DataAccessQueryParameters());
            return MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetLoadStatsById(int id)
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return

            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.id, FilterByColumnValue = id.ToString() });
            return MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetLoadStatsByDate(DateTime loadDate)
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return
            Console.WriteLine("===================>> Request Date: " + loadDate.ToString());
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.load_timestamp, FilterByColumnValue = loadDate.ToString() });
            return MapListDataToViewModel(data);
        }

        private dynamic MapListDataToViewModel(IEnumerable<LoadStat> data)
        {
            return new DataLoadStatsListViewModel()
            {
                Meta = new ApiResultListMetaInfo()
                {
                    Location = "api/dataload/",
                    TotalRecords = data.Count(),
                    Page = 1,
                    PageSize = 1
                },
                DataLoadStats = data
            };
        }
        private dynamic MapDataToViewModel(LoadStat data)
        {
            return new DataLoadStatsSingleItemViewModel()
            {
                Meta = new ApiResultMetaInfo()
                {
                    Location = "api/dataload/",
                },
                DataLoadStats = data
            };
        }


    }
}