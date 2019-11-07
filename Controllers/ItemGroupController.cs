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
    public class ItemGroupController : Controller
    {
        private readonly FloralContext _context;

        public ItemGroupController(FloralContext context)
        {
            _context = context;
        }

        // GET: ItemGroup
        public async Task<IActionResult> Index()
        {
            return View(await _context.itemGroup.ToListAsync());
        }

        // GET: ItemGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemGroup = await _context.itemGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            return View(itemGroup);
        }

        // GET: ItemGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemGroup itemGroup)
        {
            if (ModelState.IsValid)
            {
                itemGroup.createDateTime = DateTimeOffset.Now;
                itemGroup.updateDateTime = DateTimeOffset.Now;

                _context.itemGroup.Add(itemGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemGroup);
        }

        // GET: ItemGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemGroup = await _context.itemGroup.FindAsync(id);
            if (itemGroup == null)
            {
                return NotFound();
            }
            return View(itemGroup);
        }
        public class ItemGroupData { 
         public string name { get; set; }
        }

        // POST: ItemGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditItemGroup(int id, ItemGroupData itemGroupData)
        {

            var itemGroup = await _context.itemGroup.SingleOrDefaultAsync(i=>i.Id==id);
            if (id != itemGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    itemGroup.name = itemGroupData.name;
                    //_context.Update(itemGroup);
                    
                    
                    
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemGroupExists(itemGroup.Id))
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
            return View(itemGroup);
        }

        // GET: ItemGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemGroup = await _context.itemGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            return View(itemGroup);
        }

        // POST: ItemGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemGroup = await _context.itemGroup.FindAsync(id);
            _context.itemGroup.Remove(itemGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemGroupExists(int id)
        {
            return _context.itemGroup.Any(e => e.Id == id);
        }
    }
}
