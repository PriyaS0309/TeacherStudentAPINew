using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherStudentAPINew.Models
{
    public class Student
    {
        [Key]
        [Display(Name="Student ID")]
        public int ID { get; set; }

        [Display(Name = "Student Name")]
        public string Name { get; set; }
        public virtual int Teacher_ID { get; set; }
        [ForeignKey("Teacher_ID")]
        public virtual Teacher Teacher { get; set; }

    }
}
