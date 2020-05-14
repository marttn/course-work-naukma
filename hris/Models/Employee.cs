using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace coursework.Models
{
    [DisplayColumn("EmployeeId")]
    public class Employee : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HiringDate { get; set; }
        [Required]
        [Display(Name = "Houses per week")]
        public short HousesPerWeek { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public ICollection<TimeTracker> TimeTracker { get; set; }
        public ICollection<CourseCompletion> CourseCompletion { get; set; }
        public ICollection<DaysOff> DaysOff { get; set; }
        public ICollection<RemainingDaysOff> RemainingDaysOff { get; set; }
        public ICollection<Skills> Skills { get; set; }
    }
}