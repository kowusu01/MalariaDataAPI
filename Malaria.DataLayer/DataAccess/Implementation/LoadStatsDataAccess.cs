
using Common.DataAccessParameters;
using Common.Models.MalariaData;

using Microsoft.EntityFrameworkCore;
using EfCoreLayer;
using EfCoreLayer.ExtensionMethods;
namespace DataAccess
{
    public class LoadStatsDataAccess : ILoadStatsDataAccess
    {
        private readonly AppDbContext _dbContext;

        public LoadStatsDataAccess(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoadStat>> Get(DataAccessQueryParameters queryParams)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Data param: " + queryParams.FilterByColumnValue);
            return await _dbContext.LoadStats.FilterBy(queryParams).ToListAsync();
        }

    }
}