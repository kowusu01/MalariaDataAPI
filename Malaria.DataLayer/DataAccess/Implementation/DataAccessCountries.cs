

using Microsoft.EntityFrameworkCore;

using EfCoreLayer;
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer.ExtensionMethods;
using Common.Models;

namespace DataAccess
{
    public interface IDataAccessCountries
    {
        Task<IEnumerable<Country>> Get(DataAccessQueryParameters queryParams);
    }
    

    public class DataAccessCountries : IDataAccessCountries
    {
        private readonly AppDbContext _dbContext;

        public DataAccessCountries(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Country>> Get(DataAccessQueryParameters queryParams)
        {
            //return await _dbContext.CasesReportedBads.Include(badRecord => badRecord.Load).FilterBadDataSetBy(queryParams).ToListAsync();
            return await _dbContext.Countries
                .FilterCountriesSetBy(queryParams)
                .LimitBy(queryParams)
                .ToListAsync();
        }
    }
}