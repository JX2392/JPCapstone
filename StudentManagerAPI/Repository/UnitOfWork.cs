﻿using StudentManagerAPI.Repository.IRepository;
using StudentManagerAPI.Data;

namespace StudentManagerAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IStudentRepository Student { get; private set; }
        public ICourseRepository Course { get; private set; }

        public UnitOfWork(ApplicationDbContext db) {
            _db = db;

            Student = new StudentRepository(_db);

            Course = new CourseRepository(_db);
        }

        void IUnitOfWork.Save()
        {
            _db.SaveChanges();
        }
    }
}
