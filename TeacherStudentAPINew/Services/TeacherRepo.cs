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
    public class TeacherRepo : ITeacherRepo
    {
        private TeacherDbContext _teacherDbContext;
        public TeacherRepo(TeacherDbContext teacherDbContext)
        {
            _teacherDbContext = teacherDbContext;
        }
        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            var createTeacher = await _teacherDbContext.Teachers.AddAsync(teacher);
            await _teacherDbContext.SaveChangesAsync();
            return createTeacher.Entity;
        }

        public async Task<Teacher> DeleteTeacher(int id)
        {
            var deletedRow = await _teacherDbContext.Teachers.FirstOrDefaultAsync(model => model.ID == id);

            if (deletedRow!=null)
            {
                _teacherDbContext.Teachers.Remove(deletedRow);
                _teacherDbContext.SaveChanges();
            }
            return deletedRow;
        }

        public async Task<Teacher> EditTeacher(Teacher teacher)
        {
            var editedTeacher = await _teacherDbContext.Teachers.FirstOrDefaultAsync(model => model.ID == teacher.ID);
            if (editedTeacher!=null)
            {
                editedTeacher.ID = teacher.ID;
                editedTeacher.Name = teacher.Name;
            }

            return editedTeacher;
        }

        public async Task<Teacher> GetTeacherByID(int id)
        {
            var TeacherId = await _teacherDbContext.Teachers.FirstOrDefaultAsync(model => model.ID==id);

            return TeacherId;
        }

        public async Task<Teacher> GetTeacherByName(string name)
        {
            var TeacherName = await _teacherDbContext.Teachers.FirstOrDefaultAsync(model => model.Name == name);
            return TeacherName;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var TeachersList = await _teacherDbContext.Teachers.ToListAsync();
            return TeachersList;
        }
    }
}
