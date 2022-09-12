using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPINew.Models;
using TeacherStudentAPINew.Repository;

namespace TeacherStudentAPINew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepo _studentRepo;
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]

        public async Task<ActionResult>GetStudents()
        {
            return Ok(await _studentRepo.GetStudents());
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> GetStudentId(int id)
        {
            return Ok(await _studentRepo.GetStudentByID(id));
        }

        [HttpGet("{name}")]

        public async Task<ActionResult> GetStudentName(string name)
        {
            return Ok(await _studentRepo.GetStudentByName(name));
        }

        [HttpPost]

        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            var createdStudent = await _studentRepo.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentId), new { id = createdStudent.ID }, createdStudent);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<Student>> EditStudent(int id,Student student)
        {
            var editedStudent = await _studentRepo.GetStudentByID(id);
            return await _studentRepo.EditStudent(student);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Student>>DeleteStudent(int id)
        {
            return Ok(await _studentRepo.DeleteStudent(id));
        }

    }
}
