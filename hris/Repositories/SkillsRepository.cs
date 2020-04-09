using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;

namespace coursework.Repositories
{
    public class SkillsRepository : Repository, ISkillsRepository
    {
        public RequiredSkills GetRequiredSkill(int id)
        {
            return Context.RequiredSkills.Find(id);
        }

        public IEnumerable<RequiredSkills> GetRequiredSkillsForPosition(int positionId)
        {
            return Context.RequiredSkills.Where(x => x.PositionId == positionId);
        }

        public void CreateReqSkill(RequiredSkills requiredSkills)
        {
            if (requiredSkills == null) return;
            Context.RequiredSkills.Add(requiredSkills);
            SaveChanges();
        }

        public void UpdateReqSkill(RequiredSkills requiredSkills)
        {
            if (requiredSkills == null) return;
            Context.RequiredSkills.AddOrUpdate(requiredSkills);
            SaveChanges();
        }

        public void DeleteReqSkill(int id)
        {
            var data = GetRequiredSkill(id);
            if (data == null) return;
            Context.RequiredSkills.Remove(data);
            SaveChanges();
        }

        public Skills GetSkill(int id)
        {
            return Context.Skills.Find(id);
        }

        public IEnumerable<Skills> GetEmployeeSkills(int empId)
        {
            return Context.Skills.Where(x => x.EmpId == empId);
        }

        public void CreateSkill(Skills skills)
        {
            if (skills == null) return;
            Context.Skills.Add(skills);
            SaveChanges();
        }

        public void UpdateSkill(Skills skills)
        {
            if (skills == null) return;
            Context.Skills.AddOrUpdate(skills);
            SaveChanges();
        }

        public void DeleteSkill(int id)
        {
            var data = GetSkill(id);
            if (data == null) return;
            Context.Skills.Remove(data);
            SaveChanges();
        }
    }
}