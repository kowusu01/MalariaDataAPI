
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer;

namespace DataAccess
{
    public interface ILoadStatsDataAccess
    {
        Task<IEnumerable<LoadStat>> Get(DataAccessQueryParameters queryParams);
    }
}