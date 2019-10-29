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
        // POST: Supplier/Create
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

        //
        //get: Supplier/edit/id
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                NotFound();
            }

            var supplier = await _floralContext.supplier.FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null) {
                NotFound();    
            }

            return View(supplier);
        }


        //
        //put: Supplier/edit/id
        [HttpPost, ActionName("Edit")]//引导 这个action的request进来这里
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSupplier(int? id,Supplier supplier)
        {
            if (id == null) {
                NotFound();
            }
            if (ModelState.IsValid) {
                try
                {
                    var supplierUpdate =  _floralContext.Update(supplier);
                    await _floralContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("",
                   "Unable to save changes. " +
           "Try again, and if the problem persists " +
           "see your system administrator.");
                }
            }
            return View(supplier);
        }

        //
        //get: Supplier/detail/id
        public async Task<IActionResult> Detail(int? id) {
            if (id == null) {
                NotFound();
            }
            var supplier = await _floralContext.supplier.FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null) {
                NotFound();
            }
            return View(supplier);
 
        }

      //  public async Task<IActionResult> Delete(int? id) {
          //  if (id == null)
          //  {
          //      NotFound();
          //  }
         //   var supplier = await _floralContext.supplier.FirstOrDefaultAsync(s => s.Id == id);
         //   if (supplier == null)
         //   {
         //       NotFound();
         //   }
        //    return View(supplier);

       // }


        //get:supplier/delete/id
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false) {
            if (id == null) 
            {
                return NotFound();
            }
            var supplier = await _floralContext.supplier.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null) {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(supplier);
        }

        //
        //delete: Supplier/delete/id
        [HttpPost, ActionName("Delete")]//引导 这个action的request进来这里
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier =await _floralContext.supplier.FindAsync(id);
            if (supplier == null)
            {
                return RedirectToAction(nameof(Index));
            }
                try
                {

                _floralContext.supplier.Remove(supplier);
                await _floralContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException)
                {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
                }
            }
            
        }






    
}