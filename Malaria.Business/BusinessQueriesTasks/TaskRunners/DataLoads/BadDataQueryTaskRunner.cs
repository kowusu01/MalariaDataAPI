using Business.QueryTaskRunners;
using BusinessQueries.Tasks.DataLoads;
using Common.QueryParameters;
using Common.Models.Malaria;



namespace BusinessQueries.TaskRunners.DataLoads
{

    public interface IBadDataQueryTaskRunner : IBaseQueryInterface
    {
        Task<IEnumerable<CasesReportedBad>> RunTasks(QueryParameters queryParams);

    }

    public class BadDataQueryTaskRunner : AbstractBusinessTaskErrors, IBadDataQueryTaskRunner
    {
        // task to run
        private readonly IBadDataQueryTask _badDataQueryTask;

        public int MaxPageSize { get; set; } 
        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public BadDataQueryTaskRunner(IBadDataQueryTask queryTask)
        {
            _badDataQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CasesReportedBad>> RunTasks(QueryParameters queryParams)
        {
            return await _badDataQueryTask.ExecuteTask(queryParams);
        }



    }
}
