using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Models;
using StudentManager.Repository.IRepository;
using System.Linq.Expressions;

namespace StudentManager.Repository
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
