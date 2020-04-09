using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    //public class CourseAssignments
    //{
    //    public int EmpId { get; set; }
    //    public int CourseId { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }

    //}

    public class EmployeeCourses
    {
        public int EmpId { get; set; }
        public IEnumerable<OnboardingCourse> Courses { get; set; }
    }
}