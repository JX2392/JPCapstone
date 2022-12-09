using StudentManager.Data;
using StudentManagerAPI.Models;
using StudentManagerAPI.Repository.IRepository;

namespace StudentManagerAPI.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public void UpdateStudentCount()
        {
            throw new NotImplementedException();
        }
    }
}
