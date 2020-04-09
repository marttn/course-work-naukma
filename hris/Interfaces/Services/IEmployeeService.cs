using System;
using System.Collections.Generic;
using coursework.Models;

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
        DaysOff GetVacation(int empId);
        void UseVacation(int empId, short days);
        DaysOff GetSickLeave(int empId);
        void UseSickLeave(int empId, short days);
        void ApproveDayOff(int id);
        double TimeSpentForProject(int projectId, DateTime? from = null, DateTime? to = null);
        double TimeSpentByUser(int empId, DateTime? from = null, DateTime? to = null);
        void TrackTime(TimeTracker timeTracker);
        void UpdateTime(TimeTracker timeTracker);
        void DeleteTime(int id);
        void DeleteDayOff(int id);
    }
}
