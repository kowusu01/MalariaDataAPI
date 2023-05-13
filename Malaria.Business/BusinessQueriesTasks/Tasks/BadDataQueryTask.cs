using Common.DataAccessParameters;
using Common.Models.MalariaData;
using DataAccess;


namespace Business.QueryTasks
{
    public interface IBadDataQueryTask
    {
        Task<IEnumerable<CasesReportedBad>> ExecuteTask(DataAccessQueryParameters queryParams);
    }

    public class BadDataQueryTask : AbstractBusinessTaskErrors, IBadDataQueryTask
    {
        private readonly IDataAccessBadData _dataAccess;

        public BadDataQueryTask(IDataAccessBadData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<CasesReportedBad>> ExecuteTask(DataAccessQueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
