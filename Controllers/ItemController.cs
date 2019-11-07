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
    public class ItemController : Controller
    {
        private readonly FloralContext _context;

        public ItemController(FloralContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var floralContext = _context.item.Include(i => i.FlowerPackage).Include(i => i.Supplier);
            return View(await floralContext.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.item
                .Include(i => i.FlowerPackage)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {// 

            // var tag =  _context.tag;

            ViewData["packageType"] = new SelectList(_context.packageType, "Id", "name");
            ViewData["supplier"] = new SelectList(_context.supplier, "Id", "campanyName");
            ViewData["ItemGroup"] = _context.itemGroup;
            ViewData["Tag"] = _context.tag;
            ViewData["Items"] = _context.item.Where(i => i.isPackage == false);
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(Item item, string[] selectedTag, string[] selectedItem, string[] selectedItemGroup)
        {
            if (ModelState.IsValid)
            {
                item.createDateTime = DateTimeOffset.Now;
                item.updateDateTime = DateTimeOffset.Now;
                item.image = ""; 

                _context.Add(item);
                _context.SaveChanges();

                var getItemId = _context.item.OrderBy(i => i.Id).Single();

                if (selectedItem != null)
                {
                     var itemList = new List<PackageItem>();
                    foreach (var packageItem in selectedItem)
                    {
                        var packageItemToAdd = new PackageItem
                        {
                            itemId = getItemId.Id,
                            flowerPackageId = 10,
                            createDateTime = DateTimeOffset.Now,
                            updateDateTime = DateTimeOffset.Now
                        };
                        itemList.Add(packageItemToAdd);
                    }
                    await _context.SaveChangesAsync();


                }
                if (item.isTag == true)
                {
                    item.ItemTags = new List<ItemTag>();
                    foreach (var itemTag in selectedTag)
                    {
                        var itemTagToAdd = new ItemTag
                        {
                            itemId = getItemId.Id,
                            tagId = int.Parse(itemTag),
                            createDateTime = DateTimeOffset.Now,
                            updateDateTime = DateTimeOffset.Now
                        };
                        item.ItemTags.Add(itemTagToAdd);
                    }
                    await _context.SaveChangesAsync();
                }



                if (selectedItemGroup != null)
                {
                    item.ItemMmItemGroups = new List<ItemMmItemGroup>();
                    foreach (var itemMmItemGroup in selectedItemGroup)
                    {
                        var itemMmItemGroupToAdd = new ItemMmItemGroup
                        {
                            itemId = getItemId.Id,
                            itemGroupId = int.Parse(itemMmItemGroup),
                            createDateTime = DateTimeOffset.Now,
                            updateDateTime = DateTimeOffset.Now
                        };
                        item.ItemMmItemGroups.Add(itemMmItemGroupToAdd);
                    }
                    await _context.SaveChangesAsync();
                }



                return RedirectToAction(nameof(Index));
            }
            ViewData["packageType"] = new SelectList(_context.packageType, "Id", "name");
            ViewData["supplier"] = new SelectList(_context.supplier, "Id", "campanyName");
            ViewData["ItemGroup"] = _context.itemGroup;
            ViewData["Tag"] = _context.tag;
            ViewData["Items"] = _context.item.Where(i => i.isPackage == false);

            return View();
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["packageId"] = new SelectList(_context.flowerPackage, "Id", "Id", item.packageId);
            ViewData["supplierId"] = new SelectList(_context.supplier, "Id", "address", item.supplierId);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,code,sellingPrice,description,image,stock,cost,discount,isSellingItem,isTag,isStock,isPackage,supplierId,packageId,createDateTime,updateDateTime")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["packageId"] = new SelectList(_context.flowerPackage, "Id", "Id", item.packageId);
            ViewData["supplierId"] = new SelectList(_context.supplier, "Id", "address", item.supplierId);
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.item
                .Include(i => i.FlowerPackage)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.item.FindAsync(id);
            _context.item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.item.Any(e => e.Id == id);
        }
    }
}
