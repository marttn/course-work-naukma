using System;
using System.Web.Mvc;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public ActionResult PersonalProfile()
        {
            var model = new Employee
            {
                HiringDate = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PersonalProfile(Employee model)
        {
            _employeeService.Create(model);
            return View();
        }
    }
}