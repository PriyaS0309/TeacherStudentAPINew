using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPINew.Models;

namespace TeacherStudentAPINew.Repository
{
    public interface ITeacherRepo
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacherByID(int id);
        Task<Teacher> GetTeacherByName(string name);
        Task<Teacher>CreateTeacher(Teacher teacher);
        Task<Teacher> EditTeacher(Teacher teacher);
        Task<Teacher> DeleteTeacher(int id);
    }
}
