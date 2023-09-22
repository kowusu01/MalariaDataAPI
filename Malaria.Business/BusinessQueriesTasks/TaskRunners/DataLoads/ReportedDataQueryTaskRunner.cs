using Business.QueryTaskRunners;
using BusinessQueries.Tasks.DataLoads;
using Common.QueryParameters;
using Common.Models.Malaria;



namespace BusinessQueries.TaskRunners.DataLoads
{

    public interface IReportedDataQueryTaskRunner : IBaseQueryInterface
    {
        Task<IEnumerable<ReportedData>> RunTasks(QueryParameters queryParams);
    }

    public class ReportedDataQueryTaskRunner : AbstractBusinessTaskErrors, IReportedDataQueryTaskRunner
    {
        // task to run
        private readonly IReportedDataQueryTask _reportedDataQueryTask;

        public int MaxPageSize { get; set; }

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public ReportedDataQueryTaskRunner(IReportedDataQueryTask queryTask)
        {
            _reportedDataQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<ReportedData>> RunTasks(QueryParameters queryParams)
        {
            return await _reportedDataQueryTask.ExecuteTask(queryParams);
        }

    }
}
