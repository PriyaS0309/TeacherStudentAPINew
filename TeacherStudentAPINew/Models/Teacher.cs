using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherStudentAPINew.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Teacher ID")]
        public int ID { get; set; }

        [Display(Name = "Teacher Name")]
        public string  Name { get; set; }
    }
}
