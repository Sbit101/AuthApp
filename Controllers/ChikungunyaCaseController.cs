using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Controllers
{
    [Authorize]
    public class ChikungunyaCaseController : Controller
    {


        private readonly ApplicationDbContext _context;
        private static byte[]? _edit_imgdata;

        public ChikungunyaCaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return _context.ChikungunyaDBList != null ?
                        View(await _context.ChikungunyaDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.ChikungunyaDBList'  is null.");
        }


        // GET: Case Dashboard
        public async Task<IActionResult> ChikungunyaDashBoard()
        {
            return _context.ChikungunyaDBList != null ?
                        View(await _context.ChikungunyaDBList.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.DBList'  is null.");
        }

        // GET: MpoxCase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChikungunyaDBList == null)
            {
                return NotFound();
            }

            var Case = await _context.ChikungunyaDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Case == null)
            {
                return NotFound();
            }

            return View(Case);
        }



        // GET: Case/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Case/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForChikungunya,DateofFirstClinicalDiagnosis,DateSymptomsOnset,DateOnsetOfRash,PatientRashPicture")] ChikungunyaCase Case)
        {
            if (ModelState.IsValid)
            {


                //=================New image len check aug25-----------------------------
                if (Request.Form.Files.ToList().Count() <= 0)
                {
                    //StatusMessage = "Your profile picture must be less that 2 MB";
                    ViewBag.FileStats = "Your picture must upload an image of patient";

                    return View(Case    );
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
                            Case.PatientRashPicture = dataStream.ToArray();

                        }
                    }
                }

                _context.Add(Case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Case);
        }


        // GET: Case/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChikungunyaDBList == null)
            {
                return NotFound();
            }

            var Case = await _context.ChikungunyaDBList.FindAsync(id);
            if (Case == null)
            {
                return NotFound();
            }

            //new img holder new
            if (Case.PatientRashPicture != null)
            {
                _edit_imgdata = Case.PatientRashPicture;
            }
            //-----------------------------------

            return View(Case);
        }




        // POST: Case/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfTreatingPhysician,NameOfHealthcareCentre,HealthcareCentreTelephone,PatientFirstName,PatientLastName,PatientAge,PatientSex,PatientCountry,PatientTelephoneNumber,PatientCity,PatientAddress,PatientHouseHoldSize,PatientSymptomsPositiveForChikungunya,DateofFirstClinicalDiagnosis,DateSymptomsOnset,DateOnsetOfRash,PatientRashPicture")] ChikungunyaCase Case) //PatientRashPicture
        {

            if (id != Case.Id)
            {
                return NotFound();
            }


            //-----mpox-----previous Image new aug 29-------end---------------
            if (ModelState.IsValid)
            {

                if (_edit_imgdata != null)
                {
                    Case.PatientRashPicture = _edit_imgdata;

                    try
                    {
                        _context.Update(Case);
                        await _context.SaveChangesAsync();
                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CaseExists(Case.Id))
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
                                Case.PatientRashPicture = dataStream.ToArray();

                            }
                        }

                    }


                    _context.Update(Case);
                    //return RedirectToAction(nameof(Index));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(Case.Id))
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
            return View(Case);
        }



        // GET: Case/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChikungunyaDBList == null)
            {
                return NotFound();
            }

            var Case = await _context.ChikungunyaDBList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Case == null)
            {
                return NotFound();
            }

            return View(Case);
        }



        // POST: Case/Delete/5
        [Authorize(Roles = "SuperAdmin")] //----added aug 12 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChikungunyaDBList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DBList'  is null.");
            }
            var Case = await _context.ChikungunyaDBList.FindAsync(id);
            if (Case != null)
            {
                _context.ChikungunyaDBList.Remove(Case);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public static string Fmonth(int month)
        {

            var k = new Dictionary<int, string>();
            k.Add(1, "Jan");
            k.Add(2, "Feb");
            k.Add(3, "Mar");
            k.Add(4, "Apr");
            k.Add(5, "May");
            k.Add(6, "Jun");
            k.Add(7, "Jul");
            k.Add(8, "Aug");
            k.Add(9, "Sep");
            k.Add(10, "Oct");
            k.Add(11, "Nov");
            k.Add(12, "Dec");

            

            return k.FirstOrDefault(g => g.Key == month).Value;
        }


        private bool CaseExists(int id)
        {
            return (_context.MpoxCaseDBList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
