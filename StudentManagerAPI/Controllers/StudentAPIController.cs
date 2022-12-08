using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using StudentManagerAPI.Repository.IRepository;
using Refit;
using StudentManagerAPI.Models;

namespace StudentManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentAPIController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        // Gets All Students
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAll() => await _unitOfWork.Student.GetAllAsync();

        // Gets Student Details by ID
        [HttpGet("id")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
            return studentFromDb == null ? NotFound() : Ok(studentFromDb);
        }

        // Create Student
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            _unitOfWork.Student.Add(student);
            await _unitOfWork.Student.SaveAsync();

            return CreatedAtAction(nameof(Student), new {id = student.Id}, student);
        }
    }
}
