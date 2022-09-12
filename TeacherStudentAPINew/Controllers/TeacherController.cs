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
    public class TeacherController : ControllerBase
    {
        private ITeacherRepo _teacherRepo;
        public TeacherController(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetTeachers()
        {
            return Ok(await _teacherRepo.GetTeachers());
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult>GetTeacherID(int id)
        {
            return Ok(await _teacherRepo.GetTeacherByID(id));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult>GetTeacherName(string name)
        {
            return Ok(await _teacherRepo.GetTeacherByName(name));
        }

        [HttpPost]

        public async Task<ActionResult<Teacher>>CreateTeacher(Teacher teacher)
        {
            var createdTeacher = await _teacherRepo.CreateTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherID), new { id = createdTeacher.ID }, createdTeacher);
        }

        [HttpPut("{id:int}")]
        
        public async Task<ActionResult<Teacher>>EditTeacher(int id,Teacher teacher)
        {
            var editedTeacher = await _teacherRepo.GetTeacherByID(id);

            return await _teacherRepo.EditTeacher(teacher);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Teacher>>DeleteTeacher(int id)
        {
            var deletedTeacher = await _teacherRepo.GetTeacherByID(id);
            return await _teacherRepo.DeleteTeacher(id);
        }
    }
}
