using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreGeneratedDocument;

namespace AuthApp.Controllers
{
    public class WelcomeFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WelcomeFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WelcomeForm
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
              return _context.WelcomeFormDBList != null ? 
                          View(await _context.WelcomeFormDBList.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.WelcomeFormDBList'  is null.");
        }

        // GET: WelcomeForm/Details/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WelcomeFormDBList == null)
            {
                return NotFound();
            }

            var welcomeForm = await _context.WelcomeFormDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcomeForm == null)
            {
                return NotFound();
            }

            return View(welcomeForm);
        }

        // GET: WelcomeForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WelcomeForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyEmail,CompanyPhoneNumber,CompanyName,Country,City,ExpectedShipmentKg,Message,DatePosted")] WelcomeForm welcomeForm)
        {

            if (ModelState.IsValid)
            {
                welcomeForm.DatePosted = DateTime.Now;
                ///uint h = 4156678899;
                ///welcomeForm.CompanyPhoneNumber = 455556789;
                _context.Add(welcomeForm);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Redirect("/Home/Index");
            }
            return View(welcomeForm);
        }

        // GET: WelcomeForm/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WelcomeFormDBList == null)
            {
                return NotFound();
            }

            var welcomeForm = await _context.WelcomeFormDBList.FindAsync(id);
            if (welcomeForm == null)
            {
                return NotFound();
            }
            return View(welcomeForm);
        }

        // POST: WelcomeForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyEmail,CompanyPhoneNumber,CompanyName,Country,City,ExpectedShipmentKg,Message,DatePosted")] WelcomeForm welcomeForm)
        {
            if (id != welcomeForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welcomeForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelcomeFormExists(welcomeForm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(welcomeForm);
        }

        // GET: WelcomeForm/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WelcomeFormDBList == null)
            {
                return NotFound();
            }

            var welcomeForm = await _context.WelcomeFormDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcomeForm == null)
            {
                return NotFound();
            }

            return View(welcomeForm);
        }

        // POST: WelcomeForm/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WelcomeFormDBList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WelcomeFormDBList'  is null.");
            }
            var welcomeForm = await _context.WelcomeFormDBList.FindAsync(id);
            if (welcomeForm != null)
            {
                _context.WelcomeFormDBList.Remove(welcomeForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WelcomeFormExists(int id)
        {
          return (_context.WelcomeFormDBList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
