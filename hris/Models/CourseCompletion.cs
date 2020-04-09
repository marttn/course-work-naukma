namespace coursework.Models
{
    public class CourseCompletion
    {
        public int id { get; set; }
        public int EmpId { get; set; }
        public int CourseId { get; set; }
        public int PercentCompleted { get; set; }
    }
}