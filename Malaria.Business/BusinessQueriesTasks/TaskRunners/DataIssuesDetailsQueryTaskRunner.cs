using Common.DataAccessParameters;
using Common.Models.MalariaData;



namespace Business.QueryTasks
{

    public interface IDataIssuesDetailsQueryTaskRunner
    {
        Task<IEnumerable<DataIssuesDetail>> RunTasks(DataAccessQueryParameters queryParams);
    }

    public class DataIssuesDetailsQueryTaskRunner : AbstractBusinessTaskErrors, IDataIssuesDetailsQueryTaskRunner
    {
        // task to run
        private readonly IDataIssuesDetailsQueryTask _dataIssuesQueryTask;

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public DataIssuesDetailsQueryTaskRunner(IDataIssuesDetailsQueryTask queryTask)
        {
            _dataIssuesQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<DataIssuesDetail>> RunTasks(DataAccessQueryParameters queryParams)
        {
            return await _dataIssuesQueryTask.ExecuteTask(queryParams);
        }

    }
}
