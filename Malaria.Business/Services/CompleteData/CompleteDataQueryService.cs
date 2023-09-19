

using Microsoft.Extensions.Logging;

using Common.Contants;
using Common.DataAccessParameters;
using BusinessQueries.TaskRunners.DataLoads;

namespace Services.Queries
{

    public interface ICompleteDataQueryService : IGenericServiceInterface, IDataLoadServiceInterface
    {
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
        
        public async Task<dynamic> List(int? page, int? pageSize, int defaultPageSize = 10)
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return

            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters());
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetById(int id)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.Id, FilterByColumnValue = id.ToString() });
            return ServicesHelper.MapDataToViewModel(data);
        }
        public async Task<dynamic> GetByLoadId(int loadId)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.LoadId, FilterByColumnValue = loadId.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByRecordNumber(int recordNumber)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.RecordNumber, FilterByColumnValue = recordNumber.ToString() });
            return ServicesHelper.MapDataToViewModel(data);
        }
        public async Task<dynamic> GetByLoadDate(DateTime loadDate)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.LoadTimestamp, FilterByColumnValue = loadDate.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByFileName(string fileName)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.FilePath, FilterByColumnValue = fileName });
            return ServicesHelper.MapListDataToViewModel(data);
        }
    }
}