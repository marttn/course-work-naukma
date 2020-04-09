using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;

namespace coursework.Repositories
{
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return Context.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            return Context.Employees.Find(id);
        }
        public void Create(Employee employee)
        {
            Context.Employees.Add(employee);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var data = GetEmployee(id);
            if (data == null) return;
            Context.Employees.Remove(data);
            SaveChanges();
        }
        public void Update(Employee employee)
        {
            if (employee == null) return;
            Context.Employees.AddOrUpdate(employee);
            SaveChanges();

        }

        public IEnumerable<EmpDayOff> DaysOff()
        {
            return Context.EmpDaysOff.ToList();
        }

        public DaysOff GetVacation(int empId)
        {
            return Context.DaysOff.FirstOrDefault(x => x.EmpId == empId && x.Discriminator == "vacation");
        }
        //public void AddVacation(Employee employee)
        //{

        //}

        public void UseVacation(int empId, short days)
        {
            var vacay = GetVacation(empId);
            if (vacay == null) return;
            if (vacay.AmountOfDays - days < 0) return;
            vacay.AmountOfDays -= days;
            Context.DaysOff.AddOrUpdate(vacay);
            SaveChanges();
        }

        public DaysOff GetSickLeave(int empId)
        {
            return Context.DaysOff.FirstOrDefault(x => x.EmpId == empId && x.Discriminator == "sick leave");
        }

        public void UseSickLeave(int empId, short days)
        {
            var vacay = GetSickLeave(empId);
            if (vacay == null) return;
            if (vacay.AmountOfDays - days < 0) return;
            vacay.AmountOfDays -= days;
            Context.DaysOff.AddOrUpdate(vacay);
            SaveChanges();
        }

        public void ApproveDayOff(int id)
        {
            var dayOff = Context.DaysOff.Find(id);
            if (dayOff == null) return;
            dayOff.Approved = true;
            Context.DaysOff.AddOrUpdate(dayOff);
            SaveChanges();
        }

        public double TimeSpentForProject(int projectId, DateTime? from, DateTime? to)
        {
            return Query<double>("exec TimeSpentForProject @p0, @p1, @p2", projectId, from, to).FirstOrDefault();
        }
        public double TimeSpentByUser(int empId, DateTime? from, DateTime? to)
        {
            return Query<double>("exec TimeSpentByUser @p0, @p1, @p2", empId, from, to).FirstOrDefault();
        }

        public void TrackTime(TimeTracker timeTracker)
        {
            if (timeTracker == null) return;
            Context.TimeTrackers.Add(timeTracker);
            SaveChanges();
        }
        public void UpdateTime(TimeTracker timeTracker)
        {
            if (timeTracker == null) return;
            Context.TimeTrackers.AddOrUpdate(timeTracker);
            SaveChanges();
        }
        public void DeleteTime(int id)
        {
            var data = Context.TimeTrackers.Find(id);
            if (data == null) return;
            Context.TimeTrackers.Remove(data);
            SaveChanges();
        }

        public void DeleteDayOff(int id)
        {
            var data = Context.DaysOff.Find(id);
            if (data == null) return;
            Context.DaysOff.Remove(data);
            SaveChanges();
        }
    }
}