using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using coursework.Migrations;
using coursework.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace coursework
{
    public class HrisDbContext : IdentityDbContext<Employee>
    {
        public HrisDbContext()
            : base("hris", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
        public DbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<CourseCompletion> CourseCompletions { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<DaysOff> DaysOff { get; set; }
        public DbSet<EmpDayOff> EmpDaysOff { get; set; }
        public DbSet<RemainingDaysOff> RemainingDaysOff { get; set; }
        public DbSet<OnboardingCourse> OnboardingCourses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RequiredSkills> RequiredSkills { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }

    }

}