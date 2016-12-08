using EngLishSchool.Model.Models;
using EngLishSchool.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishSchool.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
       

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
         
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;

            appUser.Address = appUserViewModel.Address;

            appUser.BirthDay = appUserViewModel.BirthDay;

            appUser.Gender = appUserViewModel.Gender;

            appUser.avatar = appUserViewModel.avatar;

            appUser.BankName = appUserViewModel.BankName;

            appUser.BankBrach = appUserViewModel.BankBrach;

            appUser.BankAccount = appUserViewModel.BankAccount;

            appUser.IsBlock = appUserViewModel.IsBlock;

            appUser.TypeUserId = appUserViewModel.TypeUserId;

            appUser.ClassId = appUserViewModel.ClassId;

            appUser.SchoolId = appUserViewModel.SchoolId;

            appUser.CreatedDate = appUserViewModel.CreatedDate;

            appUser.CreateddBy = appUserViewModel.CreateddBy;

            appUser.UpdatedDate = appUserViewModel.UpdatedDate;

            appUser.UpdatedBy = appUserViewModel.UpdatedBy;
                               
    }
}
}