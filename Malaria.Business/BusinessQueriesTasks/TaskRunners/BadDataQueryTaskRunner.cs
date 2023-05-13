using Common.DataAccessParameters;
using Common.Models.MalariaData;



namespace Business.QueryTasks
{

    public interface IBadDataQueryTaskRunner
    {
        Task<IEnumerable<CasesReportedBad>> RunTasks(DataAccessQueryParameters queryParams);
    }

    public class BadDataQueryTaskRunner : AbstractBusinessTaskErrors, IBadDataQueryTaskRunner
    {
        // task to run
        private readonly IBadDataQueryTask _badDataQueryTask;

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public BadDataQueryTaskRunner(IBadDataQueryTask queryTask)
        {
            _badDataQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CasesReportedBad>> RunTasks(DataAccessQueryParameters queryParams)
        {
            return await _badDataQueryTask.ExecuteTask(queryParams);
        }

    }
}
