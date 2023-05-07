

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Common.Data.EfCore;
using Common.Models.StudentsPrototype;

namespace StudentsPrototype.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;
        readonly AppDbContext _dbContext;

        public StudentService(ILogger<StudentService> logger, AppDbContext dbContext ) 
        {
            _logger = logger;
            _dbContext = dbContext;
        }
            
        public async Task<IEnumerable<DataLoadStats>> GetStudentList()
        {
           if (_dbContext.Students!=null)
            {
                return await _dbContext.Students.ToListAsync();
            }
            return null;
        }


        public async Task<DataLoadStats> GetStudentById(int id)
        {
            if (_dbContext.Students != null)
            {
                await _dbContext.Students.FindAsync(id);
            }

            return null;
        }

        private bool StudentExists(int id)
        {
            return (_dbContext.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }

    }
}