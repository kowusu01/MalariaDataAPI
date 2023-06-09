﻿

using Microsoft.Extensions.Logging;

using Common.Models.MalariaData;
using Common.Contants;
using Common.DataAccessParameters;

using Business.QueryTasks;
using Common.ViewModels;

namespace Services.Queries
{
    

    public interface IDataIssuesDetailsQueryService : IGenericServiceInterface
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

        
        public async Task<dynamic> GetData()
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
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByLoadId(int loadId)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.LoadId, FilterByColumnValue = loadId.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
        }
        public async Task<dynamic> GetByRecordNumber(int recordNumber)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.RecordNumber, FilterByColumnValue = recordNumber.ToString() });
            return ServicesHelper.MapListDataToViewModel(data);
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
        public async Task<dynamic> GetByIssueType(string issueType)
        {
            var data = await _taskRunner.RunTasks(new DataAccessQueryParameters() { FilterByColumn = FilterByColumnEnum.IssueType, FilterByColumnValue = issueType });
            return ServicesHelper.MapListDataToViewModel(data);
        }
    }
}