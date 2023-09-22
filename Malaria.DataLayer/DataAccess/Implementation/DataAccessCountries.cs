

using Microsoft.EntityFrameworkCore;

using EfCoreLayer.WorldInfo;
using Common.QueryParameters;
using EfCoreLayer.ExtensionMethods;

using Common.Models.WorldInfo;

namespace DataAccess
{
    public interface IDataAccessCountries
    {
        Task<IEnumerable<Country>> Get(QueryParameters queryParams);
    }
    

    public class DataAccessCountries : IDataAccessCountries
    {
        private readonly WorlInfoApiDbContext _dbContext;

        public DataAccessCountries(WorlInfoApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Country>> Get(QueryParameters queryParams)
        {
            //return await _dbContext.CasesReportedBads.Include(badRecord => badRecord.Load).FilterBadDataSetBy(queryParams).ToListAsync();
            return await _dbContext.Countries
                .FilterCountriesSetBy(queryParams)
                .LimitBy(queryParams)
                .ToListAsync();
        }
    }
}