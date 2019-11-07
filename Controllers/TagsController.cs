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
    public class TagsController : Controller
    {
        private readonly FloralContext _context;

        public TagsController(FloralContext context)
        {
            _context = context;
        }

        // GET: Tags
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TagTypeNameSortParm"]=String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var tag = from t in _context.tag select t;

            if (sortOrder=="name_desc")
            {
                tag = tag.Include(t=>t.tagType).OrderByDescending(t => t.tagType.name);

            }
            else {
                tag = tag.Include(t=>t.tagType).OrderBy(t => t.tagType.name);
            }

            var tagList = await tag.AsNoTracking().Include(t=>t.tagType).ToListAsync();
            
            return View(tagList);
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.tag
                .Include(t => t.tagType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
                                                       //data       //value //text
            ViewData["tagType"] = new SelectList(_context.tagType, "Id", "name");
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                tag.createDateTime = DateTimeOffset.Now;
                tag.updateDateTime = DateTimeOffset.Now;
                _context.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tagType"] = new SelectList(_context.tagType, "Id", "name", tag.tagTypeId);
            return View(tag);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.tag.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            ViewData["tagType"] = new SelectList(_context.tagType, "Id", "name", tag.tagTypeId);
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTag(int id,  Tag tagData)
        {

            var tag = await _context.tag.FirstOrDefaultAsync(t => t.Id == id);

            if (id != tagData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tag.updateDateTime = DateTimeOffset.Now;
                    tag.name = tagData.name;
                    tag.tagTypeId = tagData.tagTypeId;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["tagType"] = new SelectList(_context.tagType, "Id", "name", tag.tagTypeId);

            return View(tagData);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.tag
                .Include(t => t.tagType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _context.tag.FindAsync(id);
            _context.tag.Remove(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return _context.tag.Any(e => e.Id == id);
        }
    }
}
