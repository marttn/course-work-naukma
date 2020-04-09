using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Repos
{
    public interface ICourseRepository
    {
        OnboardingCourse GetCourse(int id);
        IEnumerable<OnboardingCourse> GetAllOnboardingCourses();
        void CreateOnboardingCourse(OnboardingCourse onboardingCourse);
        void UpdateOnboardingCourse(OnboardingCourse onboardingCourse);
        void DeleteOnboardingCourse(int id);
        CourseModule GetModule(int id);
        IEnumerable<CourseModule> GetAllCourseModules(int courseId);
        void CreateCourseModule(CourseModule courseModule);
        void UpdateCourseModule(CourseModule courseModule);
        void DeleteCourseModule(int id);
        IEnumerable<OnboardingCourse> GetAssignedCourses(int empId);
        void CreateCourseCompletion(CourseCompletion completion);
        void UpdateCourseCompletion(CourseCompletion completion);
        void DeleteCourseCompletion(int empId, int courseId);
    }
}
