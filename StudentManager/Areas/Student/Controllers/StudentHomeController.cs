using Microsoft.AspNetCore.Mvc;
using StudentManager.Controllers;

namespace StudentManager.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentHomeController : Controller
    {
        private readonly ILogger<StudentHomeController> _logger;

        public StudentHomeController(ILogger<StudentHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
