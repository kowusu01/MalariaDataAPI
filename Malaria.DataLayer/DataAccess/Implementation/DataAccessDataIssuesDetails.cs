

using Microsoft.EntityFrameworkCore;

using EfCoreLayer.MalariaData;
using Common.QueryParameters;
using Common.Models.Malaria;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessDataIssuesDetails
    {
        Task<IEnumerable<DataIssuesDetail>> Get(QueryParameters queryParams);
    }
    

    public class DataAccessDataIssuesDetails : IDataAccessDataIssuesDetails
    {
        private readonly AppDbContext _dbContext;

        public DataAccessDataIssuesDetails(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DataIssuesDetail>> Get(QueryParameters queryParams)
        {
            //return await _dbContext.DataIssuesDetails.Include(x=>x.Load).FilterDataIssuesSetBy(queryParams).ToListAsync();
            return await _dbContext.DataIssuesDetails.FilterDataIssuesSetBy(queryParams).ToListAsync();
        }

    }
}