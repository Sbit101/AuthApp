using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AuthApp.Controllers
{
    [Authorize]
    //[Authorize(Roles = "SuperAdmin")]
    public class MpoxCaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static byte[]? _edit_imgdata;

        public MpoxCaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MpoxCase
        public async Task<IActionResult> Index()
        {
            return _context.MpoxCaseDBList != null ?
                        View(await _context.MpoxCaseDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
        }


        // GET: MpoxCase Dashboard
        public async Task<IActionResult> MpoxDashBoard()
        {
            return _context.MpoxCaseDBList != null ?
                        View(await _context.MpoxCaseDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
        }

        // GET: MpoxCase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MpoxCaseDBList == null)
            {
                return NotFound();
            }

            var mpoxCase = await _context.MpoxCaseDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mpoxCase == null)
            {
                return NotFound();
            }

            return View(mpoxCase);
        }




        // GET: MpoxCase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MpoxCase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForMpox,DateofFirstClinicalDiagnosis,DateSymptomsOnset,DateOnsetOfRash,PatientRashPicture")] MpoxCase mpoxCase)
        {
            if (ModelState.IsValid)
            {


                //=================New image len check aug25-----------------------------
                if (Request.Form.Files.ToList().Count() <= 0)
                {
                    //StatusMessage = "Your profile picture must be less that 2 MB";
                    ViewBag.FileStats = "Your picture must upload an image of patient";

                    return View(mpoxCase);
                }
                //=================New-----------------------------




                IEnumerable<IFormFile> files = Request.Form.Files.ToList();
                foreach (var file in files)
                {

                    //@todo create viewbag for size:
                    ///set max size of file bytes to 2mb if greater redirect with status msg
                    var file_len = file.Length;
                    if (file_len > 2097152)
                    {
                        //StatusMessage = "Your profile picture must be less that 2 MB";
                        ViewBag.FileStats = "Your picture must be less that 2 MB";
                        // return RedirectToPage("/HouseBuilder/Create/");
                        return View();
                    }

                    //pic one
                    if (file.Length > 0 && file.Name == "patientRashPicture")
                    {
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            mpoxCase.PatientRashPicture = dataStream.ToArray();

                        }
                    }
                }

                _context.Add(mpoxCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mpoxCase);
        }




        // GET: MpoxCase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MpoxCaseDBList == null)
            {
                return NotFound();
            }

            var mpoxCase = await _context.MpoxCaseDBList.FindAsync(id);
            if (mpoxCase == null)
            {
                return NotFound();
            }

            //new img holder new
            if (mpoxCase.PatientRashPicture != null)
            {
                _edit_imgdata = mpoxCase.PatientRashPicture;
            }
            //-----------------------------------

            return View(mpoxCase);
        }


        // POST: MpoxCase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForMpox,DateofFirstClinicalDiagnosis,DateSymptomsOnset,DateOnsetOfRash,PatientRashPicture")] MpoxCase mpoxCase) //PatientRashPicture
        {

            if (id != mpoxCase.Id)
            {
                return NotFound();
            }


            //-----mpox-----previous Image new aug 29-------end---------------
            if (ModelState.IsValid)
            {

                if (_edit_imgdata != null)
                {
                    mpoxCase.PatientRashPicture = _edit_imgdata;

                    try
                    {
                        _context.Update(mpoxCase);
                        await _context.SaveChangesAsync();
                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MpoxCaseExists(mpoxCase.Id))
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

                //----------previous Image new aug 29-------end---------------




                try
                {
      
                    //Add pic
                    IEnumerable<IFormFile> files = Request.Form.Files.ToList();
                    foreach (var file in files)
                    {

                        //@todo create viewbag for size:
                        ///set max size of file bytes to 2mb if greater redirect with status msg
                        var file_len = file.Length;
                        if (file_len > 2097152)
                        {
                            //StatusMessage = "Your profile picture must be less that 2 MB";
                            ViewBag.FileStats = "Your picture must be less that 2 MB";
                            // return RedirectToPage("/HouseBuilder/Create/");
                            return View();
                        }

                        //pic one
                        if (file.Length > 0 && file.Name == "patientRashPicture")
                        {
                            using (var dataStream = new MemoryStream())
                            {
                                await file.CopyToAsync(dataStream);
                                mpoxCase.PatientRashPicture = dataStream.ToArray();

                            }
                        }

                    }


                    _context.Update(mpoxCase);
                    //return RedirectToAction(nameof(Index));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MpoxCaseExists(mpoxCase.Id))
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
            return View(mpoxCase);
        }




        // GET: MpoxCase/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MpoxCaseDBList == null)
            {
                return NotFound();
            }

            var mpoxCase = await _context.MpoxCaseDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mpoxCase == null)
            {
                return NotFound();
            }

            return View(mpoxCase);
        }

        // POST: MpoxCase/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MpoxCaseDBList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
            }
            var mpoxCase = await _context.MpoxCaseDBList.FindAsync(id);
            if (mpoxCase != null)
            {
                _context.MpoxCaseDBList.Remove(mpoxCase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool MpoxCaseExists(int id)
        {
            return (_context.MpoxCaseDBList?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        public static string Fmonth(int month)
        {

            var dick = new Dictionary<int, string>();
            dick.Add(1, "Jan");
            dick.Add(2, "Feb");
            dick.Add(3, "Mar");
            dick.Add(4, "Apr");
            dick.Add(5, "May");
            dick.Add(6, "Jun");
            dick.Add(7, "Jul");
            dick.Add(8, "Aug");
            dick.Add(9, "Sep");
            dick.Add(10, "Oct");
            dick.Add(11, "Nov");
            dick.Add(12, "Dec");

            //var m = dick.FirstOrDefault(nig => nig.Key == 1).Value;
            //<div>@m</div>

            return dick.FirstOrDefault(nig => nig.Key == month).Value;
        }

    }
}
