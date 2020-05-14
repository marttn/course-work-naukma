using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    public class CourseModule
    {
        [Key]
        public int Id { get; set; }
        public int OnboardingCourseId { get; set; }
        public OnboardingCourse OnboardingCourse{ get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}