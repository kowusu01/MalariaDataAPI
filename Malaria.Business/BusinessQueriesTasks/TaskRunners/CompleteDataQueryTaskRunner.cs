using Common.DataAccessParameters;
using Common.Models.MalariaData;



namespace Business.QueryTasks
{

    public interface ICompleteDataQueryTaskRunner
    {
        Task<IEnumerable<CasesReportedComplete>> RunTasks(DataAccessQueryParameters queryParams);
    }

    public class CompleteDataQueryTaskRunner : AbstractBusinessTaskErrors, ICompleteDataQueryTaskRunner
    {
        // task to run
        private readonly ICompleteDataQueryTask _completeDataQueryTask;

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public CompleteDataQueryTaskRunner(ICompleteDataQueryTask queryTask)
        {
            _completeDataQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CasesReportedComplete>> RunTasks(DataAccessQueryParameters queryParams)
        {
            return await _completeDataQueryTask.ExecuteTask(queryParams);
        }

    }
}
