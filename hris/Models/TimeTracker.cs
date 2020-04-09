using System;

namespace coursework.Models
{
    public class TimeTracker
    {
        public int id { get; set; }
        public double TotalHours { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public int EmpId { get; set; }
    }
}