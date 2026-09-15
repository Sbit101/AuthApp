using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //Todo:
        //Index View:
        //Issue SuperUser should not be able to assign SuperUser roles
        //Currently this role is assignable by the superuser
        //this issue can lead to a situation where there are multiple superusers
        //created at runtime

        [Authorize(Roles = "SuperAdmin")] //auz sper user only
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }






        //Manage View:
        // Manage Method. The Get Method will be responsible to get the
        // roles per user.
        // Post Method will handle the role-assigning part of the user.
        //uses class ManageUserRolesViewModel
        // TODO issues dont superadmin display in list
        [Authorize(Roles = "SuperAdmin")] 
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();

            var k = user.Id;
            //-------------------------------------------------------------
            //new adds su roles
            //added new removes super from list displayed Aug/25
            var rox = _roleManager.Roles.Where(r => r.Name != "SuperAdmin").ToList();

            if (await _userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
             var su = await _userManager.GetRolesAsync(user);
             var sux = _roleManager.Roles.Where(r => r.Name == "SuperAdmin").ToList().FirstOrDefault();

                if (su != null && sux != null)
                {
                    var suuserRolesViewModel = new ManageUserRolesViewModel
                    {
                        RoleId = sux.Id,
                        RoleName = sux.Name
                    };

                    suuserRolesViewModel.Selected = true;
                    model.Add(suuserRolesViewModel);
                    ViewBag.AdminStats = "You are the superuser";
                    return RedirectToAction("Index");

                }
            }
            //-------------------------------------------------------------


            //foreach (var role in _roleManager.Roles) //original 
            foreach (var role in rox)// new removes superuser 
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }


        //Manage view post method:
        // issues dont superadmin display in list
        [Authorize(Roles = "SuperAdmin")] 
        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }

            var roles = await _userManager.GetRolesAsync(user);
            
           
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}
