using StudentManager.Data;
using StudentManagerAPI.Repository.IRepository;
using StudentManagerAPI.Models;

namespace StudentManagerAPI.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }
        /*void IStudentRepository.Update(Student student)
        {
            _db.Student.Update(student);
        }*/
        public bool IDNotExist(int Id)
        {
            return !_db.Student.Any(x => x.Id == Id);
        }
    }
}
