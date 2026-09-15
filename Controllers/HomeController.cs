using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.Xml;

namespace AuthApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;


        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _userManager= userManager;
            _dbContext= dbContext;

        }

        public async Task<IActionResult> Index()
        {
            //  var db = await _dbContext.HousePostingsDBList.OrderByDescending(x => x.DatePosted)
            //      .Take(10).ToListAsync();

            //  return View(db);
            return View();
        }




        //---------------------------------------------------
        //New page for superuser to access UserRoles and RoleManager
        [Authorize(Roles = "SuperAdmin")] 
        public IActionResult AdminBoardIndex()
        {
           return View();
        }

        [Authorize]
        public async Task<IActionResult> GroupChat()
        {
            //  var db = await _dbContext.HousePostingsDBList.OrderByDescending(x => x.DatePosted)
            //      .Take(10).ToListAsync();

            //  return View(db);
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}