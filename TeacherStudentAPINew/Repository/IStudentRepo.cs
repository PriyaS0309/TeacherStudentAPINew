using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPINew.Models;

namespace TeacherStudentAPINew.Repository
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentByID(int id);
        Task<Student> GetStudentByName(string name);
        Task<Student> CreateStudent(Student student);
        Task<Student> EditStudent(Student student);
        Task<Student> DeleteStudent(int id);
    }
}
