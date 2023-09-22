using BusinessQueries.Tasks.DataLoads;
using Common.QueryParameters;

namespace BusinessQueries.TaskRunners.WorldInfo
{

    public interface IQueryOperationsTaskRunner
    {
        Task<dynamic> RunSingleValueTasks(DataQueryParameters queryParams);
    }

    /// <summary>
    /// Acting as a transaction manager, this class can have multiple tasks and run them in the set sequence. 
    /// It is explicitly created by the client and all parameters supplied via the constructor.
    /// </summary>
    public class QueryOperationsTaskRunner : AbstractBusinessTaskErrors, IQueryOperationsTaskRunner
    {
        // task to run
        private readonly IQueryOperationsTask _queryOpsTask;


        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public QueryOperationsTaskRunner(IQueryOperationsTask queryTask)
        {
            _queryOpsTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<dynamic> RunSingleValueTasks(DataQueryParameters queryParams)
        {
            return await _queryOpsTask.ExecuteTask(queryParams);
        }

    }
}
