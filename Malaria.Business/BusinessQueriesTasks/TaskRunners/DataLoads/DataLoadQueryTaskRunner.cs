using Business.QueryTaskRunners;
using BusinessQueries.Tasks.DataLoads;
using Common.DataAccessParameters;
using Common.Models.MalariaData;



namespace BusinessQueries.TaskRunners.DataLoads
{

    public interface IDataLoadQueryTaskRunner : IBaseQueryInterface
    {
        Task<IEnumerable<LoadStat>> RunTasks(DataAccessQueryParameters queryParams);
    }

    /// <summary>
    /// Acting as a transaction manager, this class can have multiple tasks and run them in the set sequence. 
    /// It is explicitly created by the client and all parameters supplied via the constructor.
    /// </summary>
    public class DataLoadQueryTaskRunner : AbstractBusinessTaskErrors, IDataLoadQueryTaskRunner
    {
        // task to run
        private readonly IDataLoadQueryTask _dataLoadQueryTask;

        public int MaxPageSize { get; set; }

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public DataLoadQueryTaskRunner(IDataLoadQueryTask queryTask)
        {
            _dataLoadQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<LoadStat>> RunTasks(DataAccessQueryParameters queryParams)
        {
            return await _dataLoadQueryTask.ExecuteTask(queryParams);
        }

    }
}
