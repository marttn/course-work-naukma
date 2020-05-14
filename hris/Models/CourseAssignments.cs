using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    [NotMapped]
    public class EmployeeCourses
    {
        public int EmployeeId { get; set; }
        public IEnumerable<OnboardingCourse> Courses { get; set; }
    }
}