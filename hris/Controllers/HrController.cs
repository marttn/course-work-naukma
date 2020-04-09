using System;
using System.Diagnostics;
using System.Web.Mvc;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Controllers
{
    public class HrController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICourseService _courseService;
        private readonly IPositionService _positionService;
        private readonly ISkillsService _skillsService;

        public HrController(IEmployeeService employeeService, ICourseService courseService, IPositionService positionService, ISkillsService skillsService)
        {
            _employeeService = employeeService;
            _courseService = courseService;
            _positionService = positionService;
            _skillsService = skillsService;
        }

        public ActionResult EmployeesList()
        {
            var list = _employeeService.GetEmployees();
            return View(list);
        }
        public ActionResult AddEmployee()
        {
            var model = new Employee { HiringDate = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            try
            {
                _employeeService.Create(model);
                return RedirectToAction("EmployeesList");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return RedirectToAction("AddEmployee");
            }
        }

        public ActionResult EditEmployee(int id)
        {
            var model = _employeeService.GetEmployee(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            try
            {
                _employeeService.Update(model);
                return RedirectToAction("EmployeesList");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return RedirectToAction("EditEmployee");
            }
        }

        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.Delete(id);
                return RedirectToAction("EmployeesList");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return RedirectToAction("DeleteEmployee", id);
            }
        }

        public ActionResult CoursesList(int id)
        {
            var courseList = _courseService.GetAllOnboardingCourses();
            var model = new EmployeeCourses { EmpId = id, Courses = courseList };
            return View(model);
        }

        public ActionResult Assign(int empId, int courseId)
        {
            var course = new CourseCompletion { CourseId = courseId, EmpId = empId, PercentCompleted = 0 };
            try
            {
                _courseService.CreateCourseCompletion(course);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return RedirectToAction("Assign", empId);
        }

        public ActionResult AddPosition()
        {
            throw new NotImplementedException();
        }

        public ActionResult RequiredSkills(int positionId)
        {
            var skills = _skillsService.GetRequiredSkillsForPosition(positionId);
            return View(skills);
        }

        public ActionResult EditPosition(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult DaysOffList()
        {
            var list = _employeeService.DaysOffList();
            return View(list);
        }

        public ActionResult Approve(int id)
        {
            try
            {
                _employeeService.ApproveDayOff(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return RedirectToAction("DaysOffList");
        }

        public ActionResult DeleteDayOff(int id)
        {
            try
            {
                _employeeService.DeleteDayOff(id);
                return RedirectToAction("EmployeesList");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return RedirectToAction("DeleteEmployee", id);
            }
        }
    }
}