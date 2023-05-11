

using Microsoft.EntityFrameworkCore;

using EfCoreLayer;
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessLoadStats
    {
        Task<IEnumerable<LoadStat>> Get(DataAccessQueryParameters queryParams);
    }
    

    public class DataAccessLoadStats : IDataAccessLoadStats
    {
        private readonly AppDbContext _dbContext;

        public DataAccessLoadStats(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoadStat>> Get(DataAccessQueryParameters queryParams)
        {
            return await _dbContext.LoadStats.FilterDataLoadStatsSetBy(queryParams).ToListAsync();
        }

    }
}