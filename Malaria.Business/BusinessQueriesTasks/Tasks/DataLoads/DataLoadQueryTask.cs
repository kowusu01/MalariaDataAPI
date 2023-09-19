using Common.DataAccessParameters;
using Common.Models.MalariaData;
using DataAccess;

namespace BusinessQueries.Tasks.DataLoads
{
    public interface IDataLoadQueryTask
    {
        Task<IEnumerable<LoadStat>> ExecuteTask(DataAccessQueryParameters queryParams);
    }

    public class DataLoadQueryTask : AbstractBusinessTaskErrors, IDataLoadQueryTask
    {
        private readonly IDataAccessLoadStats _dataAccess;

        public DataLoadQueryTask(IDataAccessLoadStats dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<LoadStat>> ExecuteTask(DataAccessQueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
