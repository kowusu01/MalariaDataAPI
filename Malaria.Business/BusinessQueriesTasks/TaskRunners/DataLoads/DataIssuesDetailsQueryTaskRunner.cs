using Business.QueryTaskRunners;
using BusinessQueries.Tasks.DataLoads;
using Common.QueryParameters;
using Common.Models.Malaria;



namespace BusinessQueries.TaskRunners.DataLoads
{

    public interface IDataIssuesDetailsQueryTaskRunner : IBaseQueryInterface
    {
        Task<IEnumerable<DataIssuesDetail>> RunTasks(QueryParameters queryParams);
    }

    public class DataIssuesDetailsQueryTaskRunner : AbstractBusinessTaskErrors, IDataIssuesDetailsQueryTaskRunner
    {
        // task to run
        private readonly IDataIssuesDetailsQueryTask _dataIssuesQueryTask;

        public int MaxPageSize { get; set; }

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public DataIssuesDetailsQueryTaskRunner(IDataIssuesDetailsQueryTask queryTask)
        {
            _dataIssuesQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<DataIssuesDetail>> RunTasks(QueryParameters queryParams)
        {
            return await _dataIssuesQueryTask.ExecuteTask(queryParams);
        }

    }
}
