using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Repositories;
using coursework.Services;
using SimpleInjector;

namespace coursework
{
    public class ServiceResolver
    {
        private static Container _container;

        public static Container Configure(Container container, Lifestyle lifestyle)
        {
            RegisterServices(container, lifestyle);
            RegisterRepositories(container, lifestyle);
            _container = container;

            return container;
        }

        private static void RegisterRepositories(Container container, Lifestyle lifeStyle)
        {
            container.Register<IArchiveRepository, ArchiveRepository>(lifeStyle);
            container.Register<ICourseRepository, CourseRepository>(lifeStyle);
            container.Register<IEmployeeRepository, EmployeeRepository>(lifeStyle);
            container.Register<IPositionRepository, PositionRepository>(lifeStyle);
            container.Register<IProjectRepository, ProjectRepository>(lifeStyle);
            container.Register<ISkillsRepository, SkillsRepository>(lifeStyle);
        }

        private static void RegisterServices(Container container, Lifestyle lifeStyle)
        {
             container.Register<IArchiveService, ArchiveService>(lifeStyle);
             container.Register<ICourseService, CourseService>(lifeStyle);
             container.Register<IEmployeeService, EmployeeService>(lifeStyle);
             container.Register<IPositionService, PositionService>(lifeStyle);
             container.Register<IProjectService, ProjectService>(lifeStyle);
             container.Register<ISkillsService, SkillsService>(lifeStyle);
        }
        
        public static void Dispose()
        {
            if (_container == null) return;
            _container.Dispose();
            _container = null;
        }
    }

}