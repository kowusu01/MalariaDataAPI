using Common.QueryParameters;
using Common.Models.Malaria;
using DataAccess;

namespace BusinessQueries.Tasks.DataLoads
{
    public interface IDataLoadQueryTask
    {
        Task<IEnumerable<LoadStat>> ExecuteTask(QueryParameters queryParams);
    }

    public class DataLoadQueryTask : AbstractBusinessTaskErrors, IDataLoadQueryTask
    {
        private readonly IDataAccessLoadStats _dataAccess;

        public DataLoadQueryTask(IDataAccessLoadStats dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<LoadStat>> ExecuteTask(QueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
