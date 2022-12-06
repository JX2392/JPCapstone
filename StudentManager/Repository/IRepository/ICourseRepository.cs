using StudentManager.Models;

namespace StudentManager.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        void UpdateStudentCount();
    }
}
