using System.Diagnostics;
using coursework.Models;
using Microsoft.AspNet.Identity;

namespace coursework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HrisDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HrisDbContext context)
        {
            var idManager = new IdentityManager();
            //idManager.CreateRole(Enum.GetName(typeof(Roles), Roles.Admin));
            //idManager.CreateRole(Enum.GetName(typeof(Roles), Roles.HrManager));
            //idManager.CreateRole(Enum.GetName(typeof(Roles), Roles.LearningManager));
            //idManager.CreateRole(Enum.GetName(typeof(Roles), Roles.Employee));

            //var newUser = new Employee()
            //{
            //    Id = "01",
            //    UserName = "Admin",
            //    FirstName = "Global",
            //    LastName = "Admin",
            //    Patronymic = "Admin",
            //    Birthday = DateTime.Now,
            //    HiringDate = DateTime.Now,
            //    PhoneNumber = "1112233",
            //    HousesPerWeek = 40,
            //    PositionId = 1,
            //    Email = "globaladmin@domain.com"
            //};
            //var result = idManager.CreateUser
            //    (newUser, "123456");

            //if (result)
            //{
            //    Console.WriteLine("success");
            //    idManager.AddUserToRole(newUser.Id.ToString(),
            //        Enum.GetName(typeof(Roles), Roles.Admin));
            //}
        }

    }
}
