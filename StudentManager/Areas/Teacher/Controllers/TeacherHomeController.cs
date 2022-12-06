using Microsoft.AspNetCore.Mvc;
using StudentManager.Controllers;
using StudentManager.Models;
using StudentManager.Repository.IRepository;

namespace StudentManager.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherHomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherHomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> objCourseList = _unitOfWork.Course.GetAll();
            return View(objCourseList);
        }
    }
}
