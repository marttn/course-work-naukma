using System;
using System.Collections.Generic;
using coursework.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace coursework.Interfaces.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void Create(Employee employee);
        void Delete(int id);
        void Update(Employee employee);
        IEnumerable<EmpDayOff> DaysOffList();
        RemainingDaysOff RemainingDaysOff(int empId);
        void AddVacation(int empId);
        IEnumerable<DaysOff> DaysOff(int empId);
        DaysOff GetDayOff(int id);
        void UseDayOff(DaysOff model);
        void ApproveDayOff(int id);
        IEnumerable<TimeTracker> UserTimeTracker(int id);
        double TimeSpentForProject(int projectId, DateTime? from = null, DateTime? to = null);
        double TimeSpentByUser(int empId, DateTime? from = null, DateTime? to = null);
        void TrackTime(TimeTracker timeTracker);
        void UpdateTime(TimeTracker timeTracker);
        void DeleteTime(int id);
        void DeleteDayOff(int id);
        IEnumerable<string> IdentityUserRoles(string id);
    }
}
