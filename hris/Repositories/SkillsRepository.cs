using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var entry = GetRequiredSkill(requiredSkills.Id);
            if (entry == null) return;
            entry.Name = requiredSkills.Name;
            entry.Description = requiredSkills.Description;
            entry.MinReqYears = requiredSkills.MinReqYears;
            entry.MaxReqYears = requiredSkills.MaxReqYears;
            entry.PositionId = requiredSkills.PositionId;
            Context.Entry(entry).State = EntityState.Modified;
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
            return Context.Skills.Where(x => x.EmployeeId == empId);
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
            var entry = GetSkill(skills.Id);
            if (entry == null) return;
            entry.Name = skills.Name;
            entry.Description = skills.Description;
            entry.EmployeeId = skills.EmployeeId;
            entry.Years = skills.Years;
            Context.Entry(entry).State = EntityState.Modified;
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