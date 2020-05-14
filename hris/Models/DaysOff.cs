using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coursework.Models
{
    public class DaysOff
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        [RegularExpression("^(vacation|sick leave)$")]
        public string Discriminator { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(1, 30)]
        public short AmountOfDays { get; set; }
        [Required]
        public bool Approved { get; set; }
    }
    //[NotMapped]
    public class EmpDayOff
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Discriminator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short AmountOfDays { get; set; }
        public bool Approved { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
    }

    public class RemainingDaysOff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required] 
        [Display(Name = "Vacation")]
        public short VacationDays { get; set; }
        [Required]
        [Display(Name = "Sick leave")]
        public short SickLeaveDays { get; set; }
    }
}