namespace StudentManagerAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student{ get; }
        ICourseRepository Course { get; }

        void Save();
    }
}
