using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace coursework.Models
{
    //public class ApplicationUser : IdentityUser
    //{
    //    [Required]
    //    public string FirstName { get; set; }

    //    [Required]
    //    public string LastName { get; set; }

    //    [Required]
    //    public override string Email { get; set; }
    //}
    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new HrisDbContext()));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new HrisDbContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(Employee user, string password)
        {
            var um = new UserManager<Employee>(
                new UserStore<Employee>(new HrisDbContext()));
            var idResult = um.Create(user, password);
            Console.WriteLine(idResult.Succeeded);
            Console.WriteLine(idResult.Errors.FirstOrDefault());
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<Employee>(
                new UserStore<Employee>(new HrisDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<Employee>(
                new UserStore<Employee>(new HrisDbContext()));
            var allUserRoles = um.GetRoles(userId).ToArray();
            um.RemoveFromRoles(userId, allUserRoles);

        }
    }
}