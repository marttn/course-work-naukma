using System;

namespace coursework.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string TelNum { get; set; }
        public DateTime Birthday{ get; set; }
        public DateTime HiringDate { get; set; }
        public short HousesPerWeek { get; set; }
        public int PositionId { get; set; }

    }
}