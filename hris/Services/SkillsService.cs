using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository _skillsRepository;
        public SkillsService(ISkillsRepository skillsRepository)
        {
            _skillsRepository = skillsRepository;
        }
        public RequiredSkills GetRequiredSkill(int id)
        {
            return _skillsRepository.GetRequiredSkill(id);
        }

        public IEnumerable<RequiredSkills> GetRequiredSkillsForPosition(int positionId)
        {
            return _skillsRepository.GetRequiredSkillsForPosition(positionId);
        }

        public void CreateReqSkill(RequiredSkills requiredSkills)
        {
            _skillsRepository.CreateReqSkill(requiredSkills);
        }

        public void UpdateReqSkill(RequiredSkills requiredSkills)
        {
           _skillsRepository.UpdateReqSkill(requiredSkills);
        }

        public void DeleteReqSkill(int id)
        {
            _skillsRepository.DeleteReqSkill(id);
        }

        public Skills GetSkill(int id)
        {
            return _skillsRepository.GetSkill(id);
        }

        public IEnumerable<Skills> GetEmployeeSkills(int empId)
        {
            return _skillsRepository.GetEmployeeSkills(empId);
        }

        public void CreateSkill(Skills skills)
        {
            _skillsRepository.CreateSkill(skills);
        }

        public void UpdateSkill(Skills skills)
        {
            _skillsRepository.UpdateSkill(skills);
        }

        public void DeleteSkill(int id)
        {
            _skillsRepository.DeleteSkill(id);
        }
    }
}