using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using coursework.Models;

namespace coursework
{
    public class HrisDbContext : DbContext
    {
        public HrisDbContext()
            : base("hris")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Archive> Archives { get; set; }
        public DbSet<CourseCompletion> CourseCompletions { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<DaysOff> DaysOff { get; set; }
        public DbSet<EmpDayOff> EmpDaysOff { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OnboardingCourse> OnboardingCourses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RequiredSkills> RequiredSkills { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }

    }

}