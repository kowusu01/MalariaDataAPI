using Common.DataAccessParameters;
using Common.Models.MalariaData;
using DataAccess;

namespace Business.QueryTasks
{
	public interface IDataLoadQueryTask
	{
        Task<IEnumerable<LoadStat>> ExecuteTask(DataAccessQueryParameters queryParams);
	}

	public class DataLoadQueryTask : AbstractBusinessTaskErrors, IDataLoadQueryTask
	{
		private readonly ILoadStatsDataAccess _dataAccess;

		public DataLoadQueryTask(ILoadStatsDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<IEnumerable<LoadStat>> ExecuteTask(DataAccessQueryParameters queryParams)
		{
			return await _dataAccess.Get(queryParams);
		}
	}
}
