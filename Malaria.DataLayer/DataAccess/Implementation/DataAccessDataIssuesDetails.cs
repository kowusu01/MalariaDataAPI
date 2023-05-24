

using Microsoft.EntityFrameworkCore;

using EfCoreLayer;
using Common.DataAccessParameters;
using Common.Models.MalariaData;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessDataIssuesDetails
    {
        Task<IEnumerable<DataIssuesDetail>> Get(DataAccessQueryParameters queryParams);
    }
    

    public class DataAccessDataIssuesDetails : IDataAccessDataIssuesDetails
    {
        private readonly AppDbContext _dbContext;

        public DataAccessDataIssuesDetails(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DataIssuesDetail>> Get(DataAccessQueryParameters queryParams)
        {
            return await _dbContext.DataIssuesDetails.Include(x=>x.Load).FilterDataIssuesSetBy(queryParams).ToListAsync();
        }

    }
}