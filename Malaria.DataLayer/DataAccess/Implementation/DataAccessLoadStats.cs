

using Microsoft.EntityFrameworkCore;

using EfCoreLayer.MalariaData;
using Common.QueryParameters;
using Common.Models.Malaria;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessLoadStats
    {
        Task<IEnumerable<LoadStat>> Get(QueryParameters queryParams);
    }
    

    public class DataAccessLoadStats : IDataAccessLoadStats
    {
        private readonly AppDbContext _dbContext;

        public DataAccessLoadStats(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoadStat>> Get(QueryParameters queryParams)
        {
            return await _dbContext.LoadStats.FilterDataLoadStatsSetBy(queryParams).ToListAsync();
        }

    }
}