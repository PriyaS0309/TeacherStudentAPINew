using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPINew.Models;

namespace TeacherStudentAPINew.DbContextDb
{
    public class TeacherDbContext:DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext>options):base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
