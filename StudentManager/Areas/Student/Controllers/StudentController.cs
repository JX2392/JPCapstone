using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using StudentManager.Data;
using StudentManager.Models;
using StudentManager.Repository;
using StudentManager.Repository.IRepository;

namespace StudentManager.Controllers
{
    [Area("Student")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _toastNotification;

        public StudentController(IUnitOfWork unitOfWork, INotyfService toastNotification)
        {
            _unitOfWork = unitOfWork;
            _toastNotification = toastNotification;
        }
        // GET: Student
        public IActionResult Index()
        {
            IEnumerable<Student> studentStudentList = _unitOfWork.Student.GetAll();
            return View(studentStudentList);
        }

        // GET: Student/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0 || _unitOfWork == null)
            {
                return NotFound();
            }

            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewBag.drpCourses = PopulateCourseList();
            return View();
        }

        public List<Course> PopulateCourseList()
        {
            List<Course> courseList = new List<Course>();
            courseList = (from c in _unitOfWork.Course.GetAll() select c).ToList();
            //courseList.Insert(0, new Course { Id = 0, CourseName = "--Select Course Name--" });

            return courseList;
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("FirstName,LastName,MiddleName,DOB,Grade")]*/ Student student)
        {
            if (student.SelectedCourses != null)
            {
                int i = 0;
                foreach (var id in student.SelectedCourses)
                {
                    if (i > 0) student.StringOfCourses += ", ";
                    i++;
                    student.StringOfCourses += _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id).CourseName;
                }
            }
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(student);
                _unitOfWork.Save();
                TempData["success"] = "Student added successfully";
                _toastNotification.Success("Student added successfully");
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            ViewBag.drpCourses = PopulateCourseList();
            return View(studentFromDb);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            /*if (id != student.Id)
            {
                return NotFound();
            }*/
            if (student.SelectedCourses != null)
            {
                int i = 0;
                foreach (var courseId in student.SelectedCourses)
                {
                    if (i > 0) student.StringOfCourses += ", ";
                    i++;
                    student.StringOfCourses += _unitOfWork.Course.GetFirstOrDefault(u => u.Id == courseId).CourseName;
                }
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(student);
                _unitOfWork.Save();
                TempData["success"] = "Student edited successfully";
                _toastNotification.Success("Student edited successfully");
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var student = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var student = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            _unitOfWork.Student.Remove(student);
            _unitOfWork.Save();
            TempData["success"] = "Student deleted successfully";
            _toastNotification.Success("Student deleted successfully");
            return RedirectToAction("Index");
        }
    }
}
