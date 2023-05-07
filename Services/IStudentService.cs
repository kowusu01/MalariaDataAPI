using Common.Models.StudentsPrototype;

namespace StudentsPrototype.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<DataLoadStats>> GetStudentList();
        Task<DataLoadStats> GetStudentById(int id);
    }
}