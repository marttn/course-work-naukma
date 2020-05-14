using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coursework.Interfaces.Services;
using coursework.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace coursework.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly ICourseService _courseService;
        private readonly IProjectService _projectService;
        private readonly IArchiveService _archiveService;
        private readonly UserManager<Employee> _userManager;

        public EmployeeController(IEmployeeService employeeService, IPositionService positionService,
            ICourseService courseService, IProjectService projectService, IArchiveService archiveService)
        {
            _employeeService = employeeService;
            _positionService = positionService;
            _courseService = courseService;
            _projectService = projectService;
            _archiveService = archiveService;
            _userManager = new UserManager<Employee>(new UserStore<Employee>(new HrisDbContext()));

        }

        public ActionResult PersonalProfile()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        public ActionResult EditPersonalProfile(int id)
        {
            var model = _employeeService.GetEmployee(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditPersonalProfile(Employee model)
        {
            try
            {
                _employeeService.Update(model);
                return RedirectToAction("PersonalProfile");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return RedirectToAction("EditPersonalProfile");
            }
        }

        public ActionResult PositionDetails(int id)
        {
            var model = _positionService.Get(id);
            return View("_PositionDetailsPartial", model);
        }

        public ActionResult DaysLeft(int id)
        {
            var daysOff = _employeeService.RemainingDaysOff(id);
            var model = new RemainingDaysOff
            {
                EmployeeId = id,
                SickLeaveDays = daysOff.SickLeaveDays,
                VacationDays = daysOff.VacationDays
            };
            return View(model);
        }

        public ActionResult DaysOffList(int id)
        {
            var model = _employeeService.DaysOff(id);
            return View(model);
        }


        public ActionResult UseDayOff(int id)
        {
            var model = new DaysOff { EmployeeId = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult UseDayOff(DaysOff model)
        {
            try
            {
                _employeeService.UseDayOff(model);
                return RedirectToAction("DaysLeft", new { id = model.EmployeeId });

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return RedirectToAction("UseDayOff", new { id = model.EmployeeId });
            }
        }

        public ActionResult TrackedTime(int id)
        {
            const int pageNumber = 1;
            const int pageSize = 10;
            var model = _employeeService.UserTimeTracker(id);
            return View("_TrackedTimePartial", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DailyTracker(int id)
        {
            var model = new TimeTracker { EmployeeId = id };
            ViewBag.Projects = new SelectList(_projectService.GetAllProjects(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult DailyTracker(TimeTracker model)
        {
            try
            {
                _employeeService.TrackTime(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View(model);
            }

            return RedirectToAction("PersonalProfile");
        }

        public ActionResult CoursesList(int id)
        {
            var model = _courseService.GetAssignedCourses(id);
            return View(model);
        }

        public ActionResult UploadPhoto(int id)
        {
            var model = new Archive { OwnerId = id };
            return View("_UploadPhotoPartial", model);
        }

        [Route("UploadPhoto")]
        [HttpPost]
        public ActionResult UploadPhoto(Archive model)
        {
            _archiveService.DeletePreviousPhotos(model.OwnerId ?? 0);
            var file = Request.Files["ImageData"];
            model.Title = "Image photo";
            _archiveService.Create(file, model);

            return RedirectToAction("EditPersonalProfile", new { id = model.OwnerId });
        }

        public ActionResult DisplayPhoto(int id)
        {

            var model = _archiveService.GetEmployeeDocs(id).FirstOrDefault(x => x.Title == "Image photo");
            return PartialView("_DisplayFile", model);
        }
        public ActionResult Display(int id)
        {
            var cover = _archiveService.GetArchive(id)?.Data;
            return cover != null ? File(cover, "image/jpg") : null;
        }
    }
}
