


using EfCoreLayer.MalariaData;
using Common.QueryParameters;
using EfCoreLayer.ExtensionMethods;
using EfCore.ExtensionMethods;

namespace DataAccess
{
    public interface IDataAccessQueryOperations
    {
        Task<int> SingleValue(DataQueryParameters queryParams);
    }
    

    public class DataAccessQueryOperations : IDataAccessQueryOperations
    {
        private readonly AppDbContext _dbContext;

        public DataAccessQueryOperations(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Sum(DataQueryParameters queryParams)
        {
            // return await _dbContext.CasesReportedCompletes.Include(x=>x.Load).FilterGoodDataSetBy(queryParams).ToListAsync();
            return _dbContext.ReportedData.SingleValueOperation(queryParams);
        }
        public async Task<int> SingleValue(DataQueryParameters queryParams)
        {
            return _dbContext.ReportedData.SingleValueOperation(queryParams);
        }

    }
}