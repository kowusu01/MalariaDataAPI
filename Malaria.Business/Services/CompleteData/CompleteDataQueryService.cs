

using Microsoft.Extensions.Logging;

using Common.Models.MalariaData;
using Common.Contants;
using Common.DataAccessParameters;

using Business.QueryTasks;
using Common.ViewModels;

namespace Services.Queries
{

    public interface ICompleteDataQueryService
    {
        Task<dynamic> GetCompleteData();
        Task<dynamic> GetCompleteDataById(int id);
        Task<dynamic> GetCompleteDataByDate(DateTime date);
        Task<dynamic> GetCompleteDataByFileName(string fileName);

    }


    public class CompleteDataQueryService : ICompleteDataQueryService
    {
        private readonly ILogger<CompleteDataQueryService> _logger;

        //private readonly AppDbContext _dbContext;

        // this service has only one task runner, DataLoadStatsTaskRUnner
        private readonly ICompleteDataQueryTaskRunner _taskRunner;

        public CompleteDataQueryService(ILogger<CompleteDataQueryService> logger, ICompleteDataQueryTaskRunner runnerObj)
        {
            _logger = logger;
            //    _dbContext = dbContext;
            _taskRunner = runnerObj;
        }

        public async Task<dynamic> GetCompleteData()
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return

            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters());
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetCompleteDataById(int id)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.Id, FilterByColumnValue = id.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetCompleteDataByDate(DateTime loadDate)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.LoadTimestamp, FilterByColumnValue = loadDate.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetCompleteDataByFileName(string fileName)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.FilePath, FilterByColumnValue = fileName });
            return ServicesHelper.MapListDataToViewModel(data);
        }


    }
}