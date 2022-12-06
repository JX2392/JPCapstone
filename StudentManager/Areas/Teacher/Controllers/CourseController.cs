using StudentManager.Models;
using StudentManager.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace StudentManager.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _toastNotification;

        public CourseController(IUnitOfWork unitOfWork, INotyfService toastNotification)
        {
            _unitOfWork = unitOfWork;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> objCourseList = _unitOfWork.Course.GetAll();
            return View(objCourseList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Course added successfully";
                _toastNotification.Success("Course added successfully");
                return RedirectToAction("Index", "TeacherHome", new { area = "Teacher" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CourseFromDb = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id);

            if (CourseFromDb == null)
            {
                return NotFound();
            }
            return View(CourseFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Course edited successfully";
                _toastNotification.Success("Course added successfully");
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CourseFromDb = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id); ;

            if (CourseFromDb == null)
            {
                return NotFound();
            }
            return View(CourseFromDb);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Course.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Course deleted successfully";
            _toastNotification.Success("Course added successfully");
            return RedirectToAction("Index");
        }
    }
}
