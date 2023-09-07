

using Microsoft.EntityFrameworkCore;

using EfCoreLayer;
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessGoodData
    {
        Task<IEnumerable<CasesReportedComplete>> Get(DataAccessQueryParameters queryParams);
    }
    

    public class DataAccessCompleteData : IDataAccessGoodData
    {
        private readonly AppDbContext _dbContext;

        public DataAccessCompleteData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CasesReportedComplete>> Get(DataAccessQueryParameters queryParams)
        {
            // return await _dbContext.CasesReportedCompletes.Include(x=>x.Load).FilterGoodDataSetBy(queryParams).ToListAsync();
            return await _dbContext.CasesReportedCompletes.FilterGoodDataSetBy(queryParams).ToListAsync();

        }

    }
}