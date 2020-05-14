using System;
using System.Diagnostics;
using System.Web.Mvc;
using coursework.Interfaces.Services;
using coursework.Models;
using PagedList;

namespace coursework.Controllers
{
    [Authorize(Roles = "Admin, LearningManager")]
    public class LearningManagerController : Controller
    {
        private readonly ICourseService _courseService;

        public LearningManagerController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public ActionResult CoursesList()
        {
            const int pageNumber = 1;
            const int pageSize = 10;
            var model = _courseService.GetAllOnboardingCourses();
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CreateCourse()
        {
            var model = new OnboardingCourse();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCourse(OnboardingCourse model)
        {
            try
            {
                _courseService.CreateOnboardingCourse(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View(model);
            }
            return RedirectToAction("CoursesList");
        }

        public ActionResult EditCourse(int id)
        {
            var model = _courseService.GetCourse(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse(OnboardingCourse model)
        {
            try
            {
                _courseService.UpdateOnboardingCourse(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View(model);
            }
            return RedirectToAction("CoursesList");
        }
        public ActionResult DeleteCourse(int id)
        {
            try
            {
                _courseService.DeleteOnboardingCourse(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return RedirectToAction("CoursesList");
        }

        public ActionResult CourseModules(int id)
        {
            var model = _courseService.GetAllCourseModules(id);
            return View(model);
        }

        public ActionResult CreateCourseModule(int? id)
        {
            var model = new CourseModule {OnboardingCourseId = id ?? 0};
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCourseModule(CourseModule model)
        {
            try
            {
                _courseService.CreateCourseModule(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View(model);
            }
            return RedirectToAction("CourseModules", model.OnboardingCourseId);
        }

        public ActionResult EditCourseModule(int id)
        {
            var model = _courseService.GetModule(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourseModule(CourseModule model)
        {
            try
            {
                _courseService.UpdateCourseModule(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View(model);
            }
            return RedirectToAction("CourseModules", model.OnboardingCourseId);
        }
        public ActionResult DeleteCourseModule(int id)
        {
            var model = _courseService.GetModule(id);
            try
            {
                _courseService.DeleteCourseModule(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return RedirectToAction("CourseModules", model.OnboardingCourseId);
        }
    }
}