using Common.QueryParameters;
using DataAccess;


namespace BusinessQueries.Tasks.DataLoads
{
    public interface IQueryOperationsTask
    {
        Task<int> ExecuteTask(DataQueryParameters queryParams);
    }

    public class QueryOperationsTask : AbstractBusinessTaskErrors, IQueryOperationsTask
    {
        private readonly IDataAccessQueryOperations _dataAccess;

        public QueryOperationsTask(IDataAccessQueryOperations dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> ExecuteTask(DataQueryParameters queryParams)
        {
            return await _dataAccess.SingleValue(queryParams);
            
        }
    }
}
