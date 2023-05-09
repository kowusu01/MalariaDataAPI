
using Common.Models;
using Common.Models.MalariaData;

namespace Services.Queries
{
    public interface IDataLoadQueryService
    {
        Task<IEnumerable<LoadStat>> GetLoadStats();
        //Task<DataLoadStats> GetStudentById(int id);
    }
}