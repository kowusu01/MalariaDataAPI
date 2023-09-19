using Common.DataAccessParameters;
using Common.Models.MalariaData;
using DataAccess;


namespace BusinessQueries.Tasks.DataLoads
{
    public interface IDataIssuesDetailsQueryTask
    {
        Task<IEnumerable<DataIssuesDetail>> ExecuteTask(DataAccessQueryParameters queryParams);
    }

    public class DataIssuesDetailsQueryTask : AbstractBusinessTaskErrors, IDataIssuesDetailsQueryTask
    {
        private readonly IDataAccessDataIssuesDetails _dataAccess;

        public DataIssuesDetailsQueryTask(IDataAccessDataIssuesDetails dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<DataIssuesDetail>> ExecuteTask(DataAccessQueryParameters queryParams)
        {
            return await _dataAccess.Get(queryParams);
        }
    }
}
