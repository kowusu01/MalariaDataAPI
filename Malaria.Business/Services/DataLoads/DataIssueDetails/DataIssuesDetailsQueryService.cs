﻿

using Microsoft.Extensions.Logging;

using Common.Contants;
using Common.QueryParameters;
using BusinessQueries.TaskRunners.DataLoads;

namespace Services.Queries
{


    public interface IDataIssuesDetailsQueryService : IGenericServiceInterface, IDataLoadServiceInterface
    {
        Task<dynamic> GetByIssueType(string issueType);
    }
    
    public class DataIssuesDetailsQueryService : IDataIssuesDetailsQueryService
    {
        private readonly ILogger<DataIssuesDetailsQueryService> _logger;

        
        //private readonly AppDbContext _dbContext;

        // this service has only one task runner, DataLoadStatsTaskRUnner
        private readonly IDataIssuesDetailsQueryTaskRunner _taskRunner;

        public DataIssuesDetailsQueryService(ILogger<DataIssuesDetailsQueryService> logger, IDataIssuesDetailsQueryTaskRunner runnerObj)
        {
            //    _dbContext = dbContext;
            _logger = logger;
            _taskRunner = runnerObj;
        }

        
        public async Task<dynamic> List(int? page, int? pageSize, int defaultPageSize=10)
        {
            // select a runner 
            // convert params to querypParams
            // execute
            // convert reult to view model and return

            var data = await _taskRunner.RunTasks(new QueryParameters());
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetById(int id)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.Id, FilterByColumnValue = id.ToString() });
            return ServicesHelper.MapDataToViewModel(data);
        }
        public async Task<dynamic> GetByLoadId(int loadId)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.LoadId, FilterByColumnValue = loadId.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByRecordNumber(int recordNumber)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.RecordNumber, FilterByColumnValue = recordNumber.ToString() });
            return ServicesHelper.MapDataToViewModel(data);
        }
        public async Task<dynamic> GetByLoadDate(DateTime loadDate)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.LoadTimestamp, FilterByColumnValue = loadDate.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByFileName(string fileName)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.FilePath, FilterByColumnValue = fileName });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByIssueType(string issueType)
        {
            var data = await _taskRunner.RunTasks(new QueryParameters() { FilterByColumn = FilterByColumnEnum.IssueType, FilterByColumnValue = issueType });
            return ServicesHelper.MapListDataToViewModel(data);
        }
    }
}