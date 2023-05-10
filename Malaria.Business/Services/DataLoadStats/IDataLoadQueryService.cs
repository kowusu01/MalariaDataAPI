
using Common.Models;
using Common.Models.MalariaData;

namespace Services.Queries
{
    public interface IDataLoadQueryService
    {
        Task<dynamic> GetLoadStats();
        Task<dynamic> GetLoadStatsById(int id);
        Task<dynamic> GetLoadStatsByDate(DateTime date);
        //Task<DataLoadStats> GetStudentById(int id);
    }
}