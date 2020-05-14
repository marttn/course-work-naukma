using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    [DisplayColumn("OnboardingCourseId")]
    public class OnboardingCourse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<CourseCompletion> CourseCompletion { get; set; }
        public ICollection<CourseModule> CourseModule { get; set; }
    }
}