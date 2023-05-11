using Common.DataAccessParameters;
using Common.Models.MalariaData;

namespace BusinessQueries.Tasks
{
    public interface IQueryTaskInterface
    {
        Task<IEnumerable<IModelBaseInterface>> ExecuteTask(DataAccessQueryParameters queryParams);
    }
}

