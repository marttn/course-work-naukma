using System.Linq;
using System.Web.Mvc;
using coursework.Interfaces.Services;

namespace coursework.Controllers
{
    [Authorize(Roles = "Admin, Employee, HrManager, LearningManager")]
    public class KnowledgeBaseController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly IProjectService _projectService;
        private readonly IArchiveService _archiveService;

        public KnowledgeBaseController(IEmployeeService employeeService, IPositionService positionService, IProjectService projectService, IArchiveService archiveService)
        {
            _employeeService = employeeService;
            _positionService = positionService;
            _projectService = projectService;
            _archiveService = archiveService;
        }


        public ActionResult Index()
        {
            var model = _employeeService.GetEmployees();
            return View(model);
        }

        public ActionResult Positions()
        {
            var model = _positionService.GetAllPositions();
            return View(model);
        }

        public ActionResult Projects()
        {
            var model = _projectService.GetAllProjects();
            return View(model);
        }

        public ActionResult Search(string search)
        {
            search = search.ToLower();
            var emp = _employeeService.GetEmployees();
            var pos = _positionService.GetAllPositions();
            var proj = _projectService.GetAllProjects();
            var model = emp.Where(x => x.FirstName.ToLower() == search || x.LastName.ToLower() == search).ToList();
            if (model.Any())
                return View("Index", model);
            var model1 = pos.Where(x => x.Name.ToLower() == search).ToList();
            if (model1.Any())
                return View("Positions", model1);
            var model2 = proj.Where(x => x.Name.ToLower() == search || x.Description.ToLower() == search || x.ClientName.ToLower() == search).ToList();
            if (model2.Any())
                return View("Projects", model2);
            return RedirectToAction("Index", emp);
        }
    }
}