using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    [DisplayColumn("PositionId")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<RequiredSkills> RequiredSkills { get; set; }
    }
}