using System;

namespace coursework.Models
{
    public class DaysOff
    {
        public int id { get; set; }
        public int EmpId { get; set; }
        public string Discriminator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short AmountOfDays { get; set; }
        public bool Approved { get; set; }
    }

    public class EmpDayOff
    {
        public int id { get; set; }
        public int EmpId { get; set; }
        public string Discriminator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short AmountOfDays { get; set; }
        public bool Approved { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
    }
}