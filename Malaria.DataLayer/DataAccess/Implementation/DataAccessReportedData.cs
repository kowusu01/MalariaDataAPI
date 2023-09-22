

using Microsoft.EntityFrameworkCore;

using EfCoreLayer.MalariaData;
using Common.QueryParameters;
using Common.Models.Malaria;
using EfCoreLayer.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessReportedData
    {
        Task<IEnumerable<ReportedData>> Get(QueryParameters queryParams);
    }
    

    public class DataAccessReportedData : IDataAccessReportedData
    {
        private readonly AppDbContext _dbContext;

        public DataAccessReportedData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReportedData>> Get(QueryParameters queryParams)
        {
            // return await _dbContext.CasesReportedCompletes.Include(x=>x.Load).FilterGoodDataSetBy(queryParams).ToListAsync();
            return await _dbContext.ReportedData.FilterReportedDataSetBy(queryParams).ToListAsync();

        }

    }
}