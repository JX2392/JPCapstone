using StudentManager.Repository.IRepository;

namespace StudentManager.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student{ get; }
        ICourseRepository Course { get; }

        void Save();
    }
}
