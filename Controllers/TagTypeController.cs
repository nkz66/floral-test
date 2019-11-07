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
    public class TagTypeController : Controller
    {
        private readonly FloralContext _context;

        public TagTypeController(FloralContext context)
        {
            _context = context;
        }

        // GET: TagType
        public async Task<IActionResult> Index()
        {
            return View(await _context.tagType.ToListAsync());
        }

        // GET: TagType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagType = await _context.tagType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagType == null)
            {
                return NotFound();
            }

            return View(tagType);
        }

        // GET: TagType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TagType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagType tagType)
        {
            if (ModelState.IsValid)
            {
                tagType.createDateTime = DateTimeOffset.Now;
                tagType.updateDateTime = DateTimeOffset.Now;
                _context.Add(tagType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagType);
        }

        // GET: TagType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagType = await _context.tagType.FindAsync(id);
            if (tagType == null)
            {
                return NotFound();
            }
            return View(tagType);
        }

        // POST: TagType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TagType tagTypeData)
        {
            if (id != tagTypeData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tagType = await _context.tagType.FirstOrDefaultAsync(t => t.Id == id);
                    tagType.name = tagTypeData.name;
                    tagType.updateDateTime = DateTimeOffset.Now;

                    
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                   
                        return NotFound();
  
                }
                
            }
            return NotFound();
        }

        // GET: TagType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagType = await _context.tagType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagType == null)
            {
                return NotFound();
            }

            return View(tagType);
        }

        // POST: TagType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tagType = await _context.tagType.FindAsync(id);
            _context.tagType.Remove(tagType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagTypeExists(int id)
        {
            return _context.tagType.Any(e => e.Id == id);
        }
    }
}
