using System.ComponentModel.DataAnnotations;

namespace StudentManager.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }
        public int StudentCount { get; set; } = 0;

        public void AddStudent()
        {
            StudentCount++;
        }
    }
}
