using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace coursework.Repositories
{
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return Context.Users.ToList();
        }
        public Employee GetEmployee(int id)
        {
            return Context.Users.FirstOrDefault(x => x.UserId == id);
        }
        public void Create(Employee employee)
        {
            Context.Users.Add(employee);
            SaveChanges();
            AddVacation(employee.UserId);
        }

        public void Delete(int id)
        {
            var data = GetEmployee(id);
            if (data == null) return;
            Context.Users.Remove(data);
            SaveChanges();
        }
        public void Update(Employee employee)
        {
            if (employee == null) return;
            var entry = GetEmployee(employee.UserId);
            if (entry == null) return;
            entry.LastName = employee.LastName;
            entry.FirstName = employee.FirstName;
            entry.Patronymic = employee.Patronymic;
            entry.PhoneNumber = employee.PhoneNumber;
            entry.Email = employee.Email;
            entry.Birthday = employee.Birthday;
            entry.HiringDate = employee.HiringDate;
            entry.HousesPerWeek = employee.HousesPerWeek;
            entry.PositionId = employee.PositionId;
            Context.Entry(entry).State = EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<EmpDayOff> DaysOffList()
        {
            return Context.EmpDaysOff.ToList();
        }

        public RemainingDaysOff RemainingDaysOff(int empId)
        {
           return Query<RemainingDaysOff>($"Select * from RemainingDaysOffs where EmployeeId = {empId}").FirstOrDefault();
        }

        public void AddVacation(int empId)
        {
            var param1 = new SqlParameter("@empId", empId);
            ExecuteNonQuery("exec RemainingDays @empId", param1);
        }

        public IEnumerable<DaysOff> DaysOff(int empId)
        {
            return Query<DaysOff>($"Select * from DaysOffs where EmployeeId = {empId}");
            //return Context.DaysOff.ToList().Where(x => x.EmployeeId == empId);
        }

        public DaysOff GetDayOff(int id)
        {
            return Context.DaysOff.Find(id);
        }

        public void UseDayOff(DaysOff model)
        {
            if (model == null) return;
            if ((model.EndDate - model.StartDate).Days < model.AmountOfDays) return;
            if (model.EndDate < model.StartDate) return;
            var vacay = RemainingDaysOff(model.EmployeeId);
            switch (model.Discriminator)
            {
                case "sick leave" when vacay.SickLeaveDays < model.AmountOfDays:
                    return;
                case "sick leave":
                    vacay.SickLeaveDays -= model.AmountOfDays;
                    ExecuteNonQuery("insert into DaysOffs ([EmployeeId],[Discriminator],[StartDate],[EndDate],[AmountOfDays],[Approved]) " +
                                    $"values({model.EmployeeId}, '{model.Discriminator}',  ('{model.StartDate:yyyy-MM-dd HH:mm:ss.fff}'),  ('{model.EndDate:yyyy-MM-dd HH:mm:ss.fff}'), {model.AmountOfDays}, {(model.Approved ? 1 : 0)})");
                    SaveChanges();
                    Context.Entry(vacay).State = EntityState.Modified;
                    SaveChanges();
                    break;
                case "vacation" when vacay.VacationDays < model.AmountOfDays:
                    return;
                case "vacation":
                    vacay.VacationDays -= model.AmountOfDays;
                    ExecuteNonQuery("insert into DaysOffs ([EmployeeId],[Discriminator],[StartDate],[EndDate],[AmountOfDays],[Approved]) " +
                                    $"values({model.EmployeeId}, '{model.Discriminator}',  ('{model.StartDate:yyyy-MM-dd HH:mm:ss.fff}'),  ('{model.EndDate:yyyy-MM-dd HH:mm:ss.fff}'), {model.AmountOfDays}, {(model.Approved ? 1 : 0)})");
                    SaveChanges();
                    Context.Entry(vacay).State = EntityState.Modified;
                    SaveChanges();
                    break;
            }
        }


        public void ApproveDayOff(int id)
        {
            var dayOff = Context.DaysOff.Find(id);
            if (dayOff == null) return;
            dayOff.Approved = true;
            Context.Entry(dayOff).State = EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<TimeTracker> UserTimeTracker(int id)
        {
            return Query<TimeTracker>($"select * from TimeTrackers where EmployeeId = {id}");
        }

        public double TimeSpentForProject(int projectId, DateTime? from, DateTime? to)
        {
            var param1 = new SqlParameter("@projectId", projectId);
            var param2 = new SqlParameter("@from", from);
            var param3 = new SqlParameter("@to", to);
            return Query<double>("exec TimeSpentForProject @projectId, @from, @to", param1, param2, param3).FirstOrDefault();
        }
        public double TimeSpentByUser(int empId, DateTime? from, DateTime? to)
        {
            var param1 = new SqlParameter("@empId", empId);
            var param2 = new SqlParameter("@from", from);
            var param3 = new SqlParameter("@to", to);
            return Query<double>("exec TimeSpentByUser @empId, @from, @to", param1, param2, param3).FirstOrDefault();
        }

        public void TrackTime(TimeTracker timeTracker)
        {
            if (timeTracker == null) return;
            ExecuteNonQuery("insert into TimeTrackers (EmployeeId, ProjectId, [Date], TotalHours) " +
                            $"values ({timeTracker.EmployeeId}, {timeTracker.ProjectId}, ('{timeTracker.Date:yyyy-MM-dd HH:mm:ss.fff}'), {timeTracker.TotalHours})");
            SaveChanges();
        }

        public void UpdateTime(TimeTracker timeTracker)
        {
            if (timeTracker == null) return;
            var entry = Context.TimeTrackers.Find(timeTracker.Id);
            if (entry == null) return;
            entry.Date = timeTracker.Date;
            entry.ProjectId = timeTracker.ProjectId;
            entry.TotalHours = timeTracker.TotalHours;
            Context.Entry(entry).State = EntityState.Modified;
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

        public IEnumerable<string> IdentityUserRoles(string id)
        {
            return Context.UserRoles.Join(Context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name);
        }
    }
}