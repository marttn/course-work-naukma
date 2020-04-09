using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;

namespace coursework.Repositories
{
    public class ProjectRepository : Repository, IProjectRepository
    {
        public Project Get(int id)
        {
            return Context.Projects.Find(id);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return Context.Projects.ToList();
        }

        public void CreateProject(Project project)
        {
            if (project == null) return;
            Context.Projects.Add(project);
            SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            if (project == null) return;
            Context.Projects.AddOrUpdate(project);
            SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var data = Get(id);
            if (data == null) return;
            Context.Projects.Remove(data);
            SaveChanges();
        }
    }
}