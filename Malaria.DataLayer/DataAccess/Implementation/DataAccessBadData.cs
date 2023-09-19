

using Microsoft.EntityFrameworkCore;

using EfCoreLayer.MalariaData;
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessBadData
    {
        Task<IEnumerable<CasesReportedBad>> Get(DataAccessQueryParameters queryParams);
    }
    

    public class DataAccessBadData : IDataAccessBadData
    {
        private readonly AppDbContext _dbContext;

        public DataAccessBadData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CasesReportedBad>> Get(DataAccessQueryParameters queryParams)
        {
            //return await _dbContext.CasesReportedBads.Include(badRecord => badRecord.Load).FilterBadDataSetBy(queryParams).ToListAsync();
            return await _dbContext.CasesReportedBads.FilterBadDataSetBy(queryParams).ToListAsync();
        }
    }
}