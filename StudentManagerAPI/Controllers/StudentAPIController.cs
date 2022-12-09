using Microsoft.AspNetCore.Mvc;
using StudentManagerAPI.Repository.IRepository;
using StudentManagerAPI.Models;

namespace StudentManagerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentAPIController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        // Gets All Students
        [HttpGet]
        public IEnumerable<Student> GetAll() => _unitOfWork.Student.GetAll();

        // Gets Student Details by ID
        [HttpGet("id")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
            return studentFromDb == null ? NotFound() : Ok(studentFromDb);
        }

        // Create Student
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _unitOfWork.Student.Add(student);
            await _unitOfWork.Student.SaveAsync();

            return Ok(CreatedAtAction(nameof(Student), new {id = student.Id}, student));
        }

        // Edit Student Details
        [HttpPut("Edit/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(student);
                await _unitOfWork.Student.SaveAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
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
            _unitOfWork.Student.Remove(student);
            await _unitOfWork.Student.SaveAsync();

            return NoContent();
        }
    }
}
