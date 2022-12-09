using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Controllers;
using System.Data;

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
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
