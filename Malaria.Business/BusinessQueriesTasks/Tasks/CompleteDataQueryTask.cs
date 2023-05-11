using Common.DataAccessParameters;
using Common.Models.MalariaData;
using DataAccess;


namespace Business.QueryTasks
{
    public interface ICompleteDataQueryTask
    {
        Task<IEnumerable<CasesReportedComplete>> ExecuteTask(DataAccessQueryParameters queryParams);
    }

    public class CompleteDataQueryTask : AbstractBusinessTaskErrors, ICompleteDataQueryTask
    {
        private readonly IDataAccessGoodData _dataAccess;

        public CompleteDataQueryTask(IDataAccessGoodData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<CasesReportedComplete>> ExecuteTask(DataAccessQueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
