using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Services
{
    public interface ISkillsService
    {
        RequiredSkills GetRequiredSkill(int id);
        IEnumerable<RequiredSkills> GetRequiredSkillsForPosition(int positionId);
        void CreateReqSkill(RequiredSkills requiredSkills);
        void UpdateReqSkill(RequiredSkills requiredSkills);
        void DeleteReqSkill(int id);
        Skills GetSkill(int id);
        IEnumerable<Skills> GetEmployeeSkills(int empId);
        void CreateSkill(Skills skills);
        void UpdateSkill(Skills skills);
        void DeleteSkill(int id);
    }
}
