using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public void Create(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public IEnumerable<EmpDayOff> DaysOffList()
        {
            return _employeeRepository.DaysOff();
        }

        public DaysOff GetVacation(int empId)
        {
            return _employeeRepository.GetVacation(empId);
        }

        public void UseVacation(int empId, short days)
        {
            _employeeRepository.UseVacation(empId, days);
        }

        public DaysOff GetSickLeave(int empId)
        {
            return _employeeRepository.GetSickLeave(empId);
        }

        public void UseSickLeave(int empId, short days)
        {
            _employeeRepository.UseSickLeave(empId, days);
        }

        public void ApproveDayOff(int id)
        {
            _employeeRepository.ApproveDayOff(id);
        }

        public double TimeSpentForProject(int projectId, DateTime? @from, DateTime? to)
        {
            return _employeeRepository.TimeSpentForProject(projectId, from, to);
        }

        public double TimeSpentByUser(int empId, DateTime? @from, DateTime? to)
        {
            return _employeeRepository.TimeSpentByUser(empId, from, to);
        }

        public void TrackTime(TimeTracker timeTracker)
        {
            _employeeRepository.TrackTime(timeTracker);
        }

        public void UpdateTime(TimeTracker timeTracker)
        {
            _employeeRepository.UpdateTime(timeTracker);
        }

        public void DeleteTime(int id)
        {
            _employeeRepository.DeleteTime(id);
        }

        public void DeleteDayOff(int id)
        {
            _employeeRepository.DeleteDayOff(id);
        }
    }
}