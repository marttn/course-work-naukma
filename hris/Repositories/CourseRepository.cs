using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
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
            var entry = GetCourse(onboardingCourse.Id);
            if (entry == null) return;
            entry.Name = onboardingCourse.Name; 
            entry.Description = onboardingCourse.Description;
            Context.Entry(entry).State = EntityState.Modified; 
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
            var entry = GetModule(courseModule.Id);
            if (entry == null) return;
            entry.Name = courseModule.Name;
            entry.Description = courseModule.Description;
            Context.Entry(entry).State = EntityState.Modified;
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
            var param1 = new SqlParameter("@empId", empId);
            return Query<OnboardingCourse>("exec GetAssignedCourses @empId", param1);
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
            var entry = Context.CourseCompletions.Find(completion.Id);
            if (entry == null) return;
            entry.PercentCompleted = completion.PercentCompleted;
            Context.Entry(entry).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteCourseCompletion(int empId, int courseId)
        {
            var data = Context.CourseCompletions.FirstOrDefault(x => x.EmployeeId == empId && x.OnboardingCourseId == courseId);
            if (data == null) return;
            Context.CourseCompletions.Remove(data);
            SaveChanges();
        }
    }
}