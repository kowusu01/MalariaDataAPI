using Business.QueryTaskRunners;
using BusinessQueries.Tasks.DataLoads;
using BusinessQueries.Tasks.WorldInfo;
using Common.DataAccessParameters;
using Common.Models;


namespace BusinessQueries.TaskRunners.WorldInfo
{

    public interface ICountriesQueryTaskRunner : IBaseQueryInterface
    {
        Task<IEnumerable<Country>> RunTasks(DataAccessQueryParameters queryParams);
    }

    /// <summary>
    /// Acting as a transaction manager, this class can have multiple tasks and run them in the set sequence. 
    /// It is explicitly created by the client and all parameters supplied via the constructor.
    /// </summary>
    public class CountriesQueryTaskRunner : AbstractBusinessTaskErrors, ICountriesQueryTaskRunner
    {
        // task to run
        private readonly ICountriesQueryTask _countriesQueryTask;


        public int MaxPageSize { get; set; }

        // the runner has a reference to the EfCoreContext for commit and trxn purposes
        //private readonly EfCoreLayer.AppDbContext _appDbContext;

        public CountriesQueryTaskRunner(ICountriesQueryTask queryTask)
        {
            _countriesQueryTask = queryTask;
            //_appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Country>> RunTasks(DataAccessQueryParameters queryParams)
        {
            return await _countriesQueryTask.ExecuteTask(queryParams);
        }

    }
}
