using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Floral.Data;
using Floral.Models;

namespace Floral.Controllers
{
    public class PackageTypesController : Controller
    {
        private readonly FloralContext _context;

        public PackageTypesController(FloralContext context)
        {
            _context = context;
        }

        // GET: PackageTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.packageType.ToListAsync());
        }

        // GET: PackageTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.packageType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // GET: PackageTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PackageType packageType)
        {
            if (ModelState.IsValid)
            {
                packageType.createDateTime = DateTimeOffset.Now;
                packageType.updateDateTime = DateTimeOffset.Now;
                _context.Add(packageType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packageType);
        }

        // GET: PackageTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.packageType.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }
            return View(packageType);
        }
        public class PackageTypeData { 
        public string name { get; set; }
        } 

        // POST: PackageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPackageType(int id,  PackageTypeData packageTypeData)
        {
            var packageType = await _context.packageType.SingleOrDefaultAsync(p => p.Id == id);
            if (id != packageType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    packageType.name = packageTypeData.name;
                    packageType.updateDateTime = DateTimeOffset.Now;
                   // _context.Update(packageType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageTypeExists(packageType.Id))
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
            return View(packageType);
        }

        // GET: PackageTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.packageType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // POST: PackageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packageType = await _context.packageType.FindAsync(id);
            _context.packageType.Remove(packageType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageTypeExists(int id)
        {
            return _context.packageType.Any(e => e.Id == id);
        }
    }
}
