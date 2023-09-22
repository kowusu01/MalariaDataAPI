using Common.QueryParameters;
using Common.Models.Malaria;
using DataAccess;


namespace BusinessQueries.Tasks.DataLoads
{
    public interface IBadDataQueryTask
    {
        Task<IEnumerable<CasesReportedBad>> ExecuteTask(QueryParameters queryParams);
    }

    public class BadDataQueryTask : AbstractBusinessTaskErrors, IBadDataQueryTask
    {
        private readonly IDataAccessBadData _dataAccess;

        public BadDataQueryTask(IDataAccessBadData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<CasesReportedBad>> ExecuteTask(QueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
