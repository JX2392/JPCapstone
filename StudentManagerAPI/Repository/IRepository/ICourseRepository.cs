using StudentManagerAPI.Models;

namespace StudentManagerAPI.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        void UpdateStudentCount();
    }
}
