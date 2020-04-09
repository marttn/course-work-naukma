using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public OnboardingCourse GetCourse(int id)
        {
            return _courseRepository.GetCourse(id);
        }

        public IEnumerable<OnboardingCourse> GetAllOnboardingCourses()
        {
            return _courseRepository.GetAllOnboardingCourses();
        }

        public void CreateOnboardingCourse(OnboardingCourse onboardingCourse)
        {
            _courseRepository.CreateOnboardingCourse(onboardingCourse);
        }

        public void UpdateOnboardingCourse(OnboardingCourse onboardingCourse)
        {
            _courseRepository.UpdateOnboardingCourse(onboardingCourse);
        }

        public void DeleteOnboardingCourse(int id)
        {
            _courseRepository.DeleteOnboardingCourse(id);
        }

        public CourseModule GetModule(int id)
        {
            return _courseRepository.GetModule(id);
        }

        public IEnumerable<CourseModule> GetAllCourseModules(int courseId)
        {
            return _courseRepository.GetAllCourseModules(courseId);
        }

        public void CreateCourseModule(CourseModule courseModule)
        {
            _courseRepository.CreateCourseModule(courseModule);
        }

        public void UpdateCourseModule(CourseModule courseModule)
        {
            _courseRepository.UpdateCourseModule(courseModule);
        }

        public void DeleteCourseModule(int id)
        {
            _courseRepository.DeleteCourseModule(id);
        }

        public IEnumerable<OnboardingCourse> GetAssignedCourses(int empId)
        {
            return _courseRepository.GetAssignedCourses(empId);
        }

        public void CreateCourseCompletion(CourseCompletion completion)
        {
            _courseRepository.CreateCourseCompletion(completion);
        }

        public void UpdateCourseCompletion(CourseCompletion completion)
        {
            _courseRepository.UpdateCourseCompletion(completion);
        }

        public void DeleteCourseCompletion(int empId, int courseId)
        {
            _courseRepository.DeleteCourseCompletion(empId, courseId);
        }
    }
}