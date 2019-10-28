using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Floral.Models;
using Floral.Data;


namespace Floral.Controllers
{
    public class SupplierController : Controller
    {
        private readonly FloralContext _floralContext;
        

        public SupplierController(FloralContext context)
        {
            _floralContext = context;
        }
        //
        //GET:/supplier/
        public async Task<IActionResult> Index()
        {
            var supplier = await _floralContext.supplier.AsNoTracking().ToListAsync();
            return View(supplier);
        }
        //
        //GET:/supplier/create/
        public IActionResult Create()
        {
            ViewData["message"] = "add supplier";
            return View();
        }
        //
        //GET:/supplier/privacy/
        public IActionResult Edit()
        {
            return View();
        }


        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier) {
            try
            {

                supplier.createDateTime = DateTimeOffset.Now;
                supplier.updateDateTime = DateTimeOffset.Now;
                
                if (ModelState.IsValid) { //check model has error
                    _floralContext.supplier.Add(supplier);
                    await _floralContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException) {
                ModelState.AddModelError("", 
                    "Unable to save changes. " +
            "Try again, and if the problem persists " +
            "see your system administrator.");
            }

            return View(supplier);
        }
        
    }
}