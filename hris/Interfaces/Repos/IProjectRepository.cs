﻿using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Repos
{
    public interface IProjectRepository
    {
        Project Get(int id);
        IEnumerable<Project> GetAllProjects();
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
