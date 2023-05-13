using Business.QueryTasks;
using Common.Contants;
using Common.DataAccessParameters;
using Microsoft.Extensions.Logging;

namespace Services.Queries
{
    public interface IGenericServiceInterface
    {
        Task<dynamic> GetData();
        Task<dynamic> GetById(int id);
        Task<dynamic> GetByLoadId(int loadId);
        Task<dynamic> GetByRecordNumber(int recordNumber);
        Task<dynamic> GetByLoadDate(DateTime date);
        Task<dynamic> GetByFileName(string fileName);
    }
}
