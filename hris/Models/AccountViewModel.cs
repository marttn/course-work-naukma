// New namespace imports:

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;

namespace coursework.Models
{
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage =
            "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage =
            "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }


    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage =
            "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage =
            "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        [Required]
        [Display(Name = "Houses per week")]
        public short HousesPerWeek { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public int PositionId { get; set; }

        public Employee GetUser()
        {
            var user = new Employee
            {
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Patronymic = Patronymic,
                Birthday = Birthday,
                HiringDate = DateTime.Now,
                Email = Email,
                HousesPerWeek = HousesPerWeek,
                PositionId = PositionId
            };
            return user;
        }
    }


    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        public EditUserViewModel(Employee user)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }


    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(Employee user)
            : this()
        {
            UserName = user.UserName;

            var db = new HrisDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = db.Roles;
            foreach (var role in allRoles)
            {
                var rvm = new SelectRoleEditorViewModel(role);
                Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                    Roles.Find(r => r.RoleId == userRole.RoleId);
                checkUserRole.Selected = true;
            }
        }

        public string UserName { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            RoleId = role.Id;
            RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

    enum Roles
    {
        Admin,
        HrManager,
        LearningManager,
        Employee
    }
}