using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Controllers
{
    public class MeaslesCaseController : Controller
    {


        private readonly ApplicationDbContext _context;
        private static byte[]? _edit_imgdata;

        public MeaslesCaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return _context.MeaslesDBList != null ?
                        View(await _context.MeaslesDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MeaslesDBList'  is null.");
        }


        // GET:Diphtheria Dashboard
        public async Task<IActionResult> MeaslesDashBoard()
        {
            return _context.MeaslesDBList != null ?
                        View(await _context.MeaslesDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MeaslesDBList'  is null.");
        }



        // GET: measlesCaseController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeaslesDBList == null)
            {
                return NotFound();
            }

            var measlesCase = await _context.MeaslesDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measlesCase == null)
            {
                return NotFound();
            }

            return View(measlesCase);
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
        public async Task<IActionResult> Create([Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForMeasles,DateofFirstClinicalDiagnosis,DateSymptomsOnset,PatientMeaslesPicture")] MeaslesCase measlesCase)
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
                    return View(measlesCase);
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
                            measlesCase.PatientMeaslesPicture = dataStream.ToArray();

                        }
                    }
                }

                _context.Add(measlesCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measlesCase);
        }



        // GET: DiphtheriaCaseController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeaslesDBList == null)
            {
                return NotFound();
            }

            var measlesCase = await _context.MeaslesDBList.FindAsync(id);
            if (measlesCase == null)
            {
                return NotFound();
            }

            //new img holder
            if (measlesCase.PatientMeaslesPicture != null)
            {
                //byte[] t = diphtheriaCase.PatientDiphtheriaPicture;
                _edit_imgdata = measlesCase.PatientMeaslesPicture;
            }


            return View(measlesCase);
        }

        // POST: DiphtheriaCaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForMeasles,DateofFirstClinicalDiagnosis,DateSymptomsOnset,PatientMeaslesPicture")] MeaslesCase measlesCase)
        {

            if (id != measlesCase.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                //-----Diphtheria-----previous Image cacher new aug 29----------------------
                if (_edit_imgdata != null)
                {
                    measlesCase.PatientMeaslesPicture = _edit_imgdata;

                    try
                    {
                        _context.Update(measlesCase);
                        await _context.SaveChangesAsync();
                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MeaslesCaseExists(measlesCase.Id))
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
                                    measlesCase.PatientMeaslesPicture = dataStream.ToArray();

                                }

                            }

                        }



                        _context.Update(measlesCase);
                        //return RedirectToAction(nameof(Index));
                        await _context.SaveChangesAsync();


                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MeaslesCaseExists(measlesCase.Id))
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
            return View(measlesCase);
        }





        // GET: DiphtheriaCaseController/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeaslesDBList == null)
            {
                return NotFound();
            }

            var measlesCase = await _context.MeaslesDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measlesCase == null)
            {
                return NotFound();
            }

            return View(measlesCase);
        }

        // POST: DiphtheriaCaseController/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeaslesDBList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MpoxDBList'  is null.");
            }
            var measlesCase = await _context.MeaslesDBList.FindAsync(id);
            if (measlesCase != null)
            {
                _context.MeaslesDBList.Remove(measlesCase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool MeaslesCaseExists(int id)
        {
            return (_context.MeaslesDBList?.Any(e => e.Id == id)).GetValueOrDefault();
        }




    }
}
