using System;
using System.Activities.Expressions;
using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    public class RequiredSkills
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public double MinReqYears { get; set; }
        [Required]
        [Range(0.5, 100)]
        public double MaxReqYears { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}