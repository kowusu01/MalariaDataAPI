using Common.QueryParameters;
using Common.Models.Malaria;
using DataAccess;


namespace BusinessQueries.Tasks.DataLoads
{
    public interface IReportedDataQueryTask
    {
        Task<IEnumerable<ReportedData>> ExecuteTask(QueryParameters queryParams);
    }

    public class ReportedDataQueryTask : AbstractBusinessTaskErrors, IReportedDataQueryTask
    {
        private readonly IDataAccessReportedData _dataAccess;

        public ReportedDataQueryTask(IDataAccessReportedData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<ReportedData>> ExecuteTask(QueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
