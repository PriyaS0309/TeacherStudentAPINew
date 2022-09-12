using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPINew.DbContextDb;
using TeacherStudentAPINew.Models;
using TeacherStudentAPINew.Repository;

namespace TeacherStudentAPINew.Services
{
    public class StudentRepo : IStudentRepo
    {
        private TeacherDbContext _teacherDbContext;

        public StudentRepo(TeacherDbContext teacherDbContext)
        {
            _teacherDbContext = teacherDbContext;
        }
        public async Task<Student> CreateStudent(Student student)
        {
            var createdStudent = await _teacherDbContext.Students.AddAsync(student);
            await _teacherDbContext.SaveChangesAsync();
            return createdStudent.Entity;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var deletedStudent = await _teacherDbContext.Students.FirstOrDefaultAsync(model => model.ID == id);
            if(deletedStudent!=null)
            {
                _teacherDbContext.Students.Remove(deletedStudent);
                _teacherDbContext.SaveChanges();
            }
            return deletedStudent;
        }

        public async Task<Student> EditStudent(Student student)
        {
            var editedStudent = await _teacherDbContext.Students.FirstOrDefaultAsync(model => model.ID == student.ID);
            if (editedStudent!=null)
            {
                editedStudent.ID = student.ID;
                editedStudent.Name = student.Name;
            }
            return editedStudent;
        }

        public async Task<Student> GetStudentByID(int id)
        {
            var studentId = await _teacherDbContext.Students.FirstOrDefaultAsync(model => model.ID == id);
            return studentId;
        }

        public async Task<Student> GetStudentByName(string name)
        {
            var studentName = await _teacherDbContext.Students.FirstOrDefaultAsync(model => model.Name ==name);
            return studentName;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var studentList = await _teacherDbContext.Students.ToListAsync();
            return studentList;
        }
    }
}
