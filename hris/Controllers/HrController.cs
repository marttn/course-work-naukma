using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using coursework.Interfaces.Services;
using coursework.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace coursework.Controllers
{
    [Authorize(Roles = "Admin, HrManager")]
    public class HrController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICourseService _courseService;
        private readonly IPositionService _positionService;
        private readonly IProjectService _projectService;
        private readonly ISkillsService _skillsService;
        private UserManager<Employee> _userManager { get; set; }

        public HrController(IEmployeeService employeeService, ICourseService courseService, IPositionService positionService, IProjectService projectService, ISkillsService skillsService)
        {
            _employeeService = employeeService;
            _courseService = courseService;
            _positionService = positionService;
            _projectService = projectService;
            _skillsService = skillsService;
            _userManager = new UserManager<Employee>(new UserStore<Employee>(new HrisDbContext()));

        }

        public ActionResult EmployeesList()
        {
            var list = _employeeService.GetEmployees();
            list = list.Where(x => !(_userManager.IsInRole(x.Id, Enum.GetName(typeof(Roles), Roles.Admin))));
            return View(list);
        }
        public ActionResult AddEmployee()
        {
            var model = new Employee { HiringDate = DateTime.Now };
            ViewBag.Positions = new SelectList(_positionService.GetAllPositions(), "Id", "Name");
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
            var model = new EmployeeCourses { EmployeeId = id, Courses = courseList };
            return View(model);
        }

        public ActionResult Assign(int empId, int courseId)
        {
            var course = new CourseCompletion { OnboardingCourseId = courseId, EmployeeId = empId, PercentCompleted = 0 };
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

        public ActionResult ManagePositions()
        {
            var model = _positionService.GetAllPositions();
            return View(model);
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