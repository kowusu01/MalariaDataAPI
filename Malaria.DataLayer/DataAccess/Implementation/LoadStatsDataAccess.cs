
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LoadStatsDataAccess : ILoadStatsDataAccess
    {
        private readonly AppDbContext _dbContext;

        public LoadStatsDataAccess(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoadStat>> Get(DataAccessQueryParameters queryParams) => await _dbContext.LoadStats.ToListAsync();

    }
}