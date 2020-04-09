using System.Collections.Generic;
using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Project Get(int id)
        {
           return _projectRepository.Get(id);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public void CreateProject(Project project)
        {
            _projectRepository.CreateProject(project);
        }

        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }
    }
}