using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    public class Skills
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0.1, 100)]
        public double Years { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}