using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;

namespace coursework.Repositories
{
    public class CourseRepository : Repository, ICourseRepository
    {
        public OnboardingCourse GetCourse(int id)
        {
            return Context.OnboardingCourses.Find(id);
        }

        public IEnumerable<OnboardingCourse> GetAllOnboardingCourses()
        {
            return Context.OnboardingCourses.ToList();
        }

        public void CreateOnboardingCourse(OnboardingCourse onboardingCourse)
        {
            if (onboardingCourse == null) return;
            Context.OnboardingCourses.Add(onboardingCourse);
            SaveChanges();
        }

        public void UpdateOnboardingCourse(OnboardingCourse onboardingCourse)
        {
            if (onboardingCourse == null) return;
            Context.OnboardingCourses.AddOrUpdate(onboardingCourse);
            SaveChanges();
        }

        public void DeleteOnboardingCourse(int id)
        {
            var data = GetCourse(id);
            if (data == null) return;
            Context.OnboardingCourses.Remove(data);
            SaveChanges();
        }

        public CourseModule GetModule(int id)
        {
            return Context.CourseModules.Find(id);
        }

        public IEnumerable<CourseModule> GetAllCourseModules(int courseId)
        {
            return Context.CourseModules.ToList();
        }

        public void CreateCourseModule(CourseModule courseModule)
        {
            if (courseModule == null) return;
            Context.CourseModules.Add(courseModule);
            SaveChanges();
        }

        public void UpdateCourseModule(CourseModule courseModule)
        {
            if (courseModule == null) return;
            Context.CourseModules.AddOrUpdate(courseModule);
            SaveChanges();
        }

        public void DeleteCourseModule(int id)
        {
            var data = GetModule(id);
            if (data == null) return;
            Context.CourseModules.Remove(data);
            SaveChanges();
        }

        public IEnumerable<OnboardingCourse> GetAssignedCourses(int empId)
        {
            return Query<OnboardingCourse>("exec GetAssignedCourses @p1", empId);
        }

        public void CreateCourseCompletion(CourseCompletion completion)
        {
            if (completion == null) return;
            Context.CourseCompletions.Add(completion);
            SaveChanges();
        }

        public void UpdateCourseCompletion(CourseCompletion completion)
        {
            if (completion == null) return;
            Context.CourseCompletions.AddOrUpdate(completion);
            SaveChanges();
        }

        public void DeleteCourseCompletion(int empId, int courseId)
        {
            var data = Context.CourseCompletions.FirstOrDefault(x => x.EmpId == empId && x.CourseId == courseId);
            if (data == null) return;
            Context.CourseCompletions.Remove(data);
            SaveChanges();
        }
    }
}