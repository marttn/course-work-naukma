using System;
using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    public class CourseCompletion
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int OnboardingCourseId { get; set; }
        public OnboardingCourse OnboardingCourse { get; set; }
        [Required]
        [Range(0, 100)]
        public int PercentCompleted { get; set; }
    }
}