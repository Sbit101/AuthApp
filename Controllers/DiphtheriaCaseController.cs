using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AuthApp.Controllers
{
    [Authorize]
    //[Authorize(Roles = "SuperAdmin")]
    public class DiphtheriaCaseController : Controller
    {

        private readonly ApplicationDbContext _context;
        private static byte[]? _edit_imgdata;

        public DiphtheriaCaseController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: DiphtheriaCaseController
        //public ActionResult Index()
        //{
        //    return View();
       // }
       //GET
        public async Task<IActionResult> Index()
        {
            return _context.DiphtheriaDBList != null ?
                        View(await _context.DiphtheriaDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
        }


        // GET:Diphtheria Dashboard
        public async Task<IActionResult> DiphtheriaDashBoard()
        {
            return _context.DiphtheriaDBList != null ?
                        View(await _context.DiphtheriaDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
        }



        // GET: DiphtheriaCaseController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiphtheriaDBList == null)
            {
                return NotFound();
            }

            var diphtheriaCase = await _context.DiphtheriaDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diphtheriaCase == null)
            {
                return NotFound();
            }

            return View(diphtheriaCase);
        }




        // GET: DiphtheriaCaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        //["Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForDiphtheria,DateofFirstClinicalDiagnosis,DateSymptomsOnset,PatientDiphtheriaPicture"]
        // POST: DiphtheriaCaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForDiphtheria,DateofFirstClinicalDiagnosis,DateSymptomsOnset,PatientDiphtheriaPicture")] DiphtheriaCase diphtheriaCase)
        {
            if (ModelState.IsValid)
            {



                //=================New image len check aug25-----------------------------
                if (Request.Form.Files.ToList().Count() <= 0)
                {
                    //StatusMessage = "Your profile picture must be less that 2 MB";
                    ViewBag.FileStats = "Your picture must upload an image of patient";

                    //var px = _context.DiphtheriaDBList.Find(id)?.PatientDiphtheriaPicture;
                    // return RedirectToPage("/HouseBuilder/Create/");
                    return View(diphtheriaCase);
                }
                //=================New-----------------------------





                //Add Housepicone
                IEnumerable<IFormFile> files = Request.Form.Files.ToList();
                //IFormFile file = Request.Form.Files.First();
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
                            diphtheriaCase.PatientDiphtheriaPicture = dataStream.ToArray();

                        }
                    }
                }

                _context.Add(diphtheriaCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diphtheriaCase);
        }



        // GET: DiphtheriaCaseController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiphtheriaDBList == null)
            {
                return NotFound();
            }

            var diphtheriaCase = await _context.DiphtheriaDBList.FindAsync(id);
            if (diphtheriaCase == null)
            {
                return NotFound();
            }

            //new img holder
            if (diphtheriaCase.PatientDiphtheriaPicture != null) {
                //byte[] t = diphtheriaCase.PatientDiphtheriaPicture;
                _edit_imgdata = diphtheriaCase.PatientDiphtheriaPicture; 
            }
            

            return View(diphtheriaCase);
        }

        // POST: DiphtheriaCaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForDiphtheria,DateofFirstClinicalDiagnosis,DateSymptomsOnset,PatientDiphtheriaPicture")] DiphtheriaCase diphtheriaCase)
        {

            if (id != diphtheriaCase.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                //-----Diphtheria-----previous Image cacher new aug 29----------------------
                if (_edit_imgdata != null)
                {
                    diphtheriaCase.PatientDiphtheriaPicture = _edit_imgdata;

                    try
                    {
                        _context.Update(diphtheriaCase);
                        await _context.SaveChangesAsync();
                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DiphtheriaCaseExists(diphtheriaCase.Id))
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


                if (Request.Form.Files.ToList().Count > 0 && Request.Form.Files.ToList() != null)
                {
                    try
                    {

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
                                    diphtheriaCase.PatientDiphtheriaPicture = dataStream.ToArray();

                                }

                            }

                        }



                        _context.Update(diphtheriaCase);
                        //return RedirectToAction(nameof(Index));
                        await _context.SaveChangesAsync();


                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DiphtheriaCaseExists(diphtheriaCase.Id))
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
            }
                return View(diphtheriaCase);
            }





        // GET: DiphtheriaCaseController/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiphtheriaDBList == null)
            {
                return NotFound();
            }

            var diphtheriaCase = await _context.DiphtheriaDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diphtheriaCase == null)
            {
                return NotFound();
            }

            return View(diphtheriaCase);
        }

        // POST: DiphtheriaCaseController/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiphtheriaDBList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
            }
            var diphtheriaCase = await _context.DiphtheriaDBList.FindAsync(id);
            if (diphtheriaCase != null)
            {
                _context.DiphtheriaDBList.Remove(diphtheriaCase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool DiphtheriaCaseExists(int id)
        {
            return (_context.DiphtheriaDBList?.Any(e => e.Id == id)).GetValueOrDefault();
        }




    }
}
