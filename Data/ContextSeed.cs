using AuthApp.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace AuthApp.Data
{
 
    public static class ContextSeed
    {
        public enum Roles
        {
            SuperAdmin,
            Admin,
            Moderator,
            Basic
        }

        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
             //Seed Roles
             await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
             await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
             await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
             await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
         }




     }
}
    

