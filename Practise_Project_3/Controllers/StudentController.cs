using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practise_Project_3.Models;
using Practise_Project_3.Services;

namespace Practise_Project_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("All")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var stud = _studentService.GetStudentById(id);
            if (stud is null)
                return NotFound();
            return Ok(stud);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody]Student student)
        {
            var stud = _studentService.AddStudent(student);
            return CreatedAtAction(nameof(AddStudent), new { id = stud.Id }, student);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Student> UpdateStudent(int id, [FromBody] Student student)
        {
            if (!_studentService.UpdateStudent(id, student))
            {
                return NotFound();
            }
            return Ok("Added Successfully");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            if (!_studentService.DeleteStudent(id))
            {
                return NotFound("Student is not avilable");
            }
            return Ok("Deleted Successfully");


        }

    }
}
