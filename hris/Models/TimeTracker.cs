using System;
using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    public class TimeTracker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0,24)]
        public double TotalHours { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public Project Project{ get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee{ get; set; }
    }
}