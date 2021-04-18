using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using texim.Data;
using texim.Models;

namespace texim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BlogTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogTags.ToListAsync());
        }

        // GET: Admin/BlogTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogTag = await _context.BlogTags
                .FirstOrDefaultAsync(m => m.BlogTagId == id);
            if (blogTag == null)
            {
                return NotFound();
            }

            return View(blogTag);
        }

        // GET: Admin/BlogTags/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Admin/BlogTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BlogTag blogTag)
        {
            if (ModelState.IsValid)
            {
                blogTag.IsDelete = false;
                _context.Add(blogTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogTag = await _context.BlogTags.FindAsync(id);
            if (blogTag == null)
            {
                return NotFound();
            }
            return View(blogTag);
        }

        // POST: Admin/BlogTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogTagId,BlogId,TagName,Slug,IsDelete")] BlogTag blogTag)
        {
            if (id != blogTag.BlogTagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogTagExists(blogTag.BlogTagId))
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
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogTag = await _context.BlogTags
                .FirstOrDefaultAsync(m => m.BlogTagId == id);
            if (blogTag == null)
            {
                return NotFound();
            }

            return View(blogTag);
        }

        // POST: Admin/BlogTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogTag = await _context.BlogTags.FindAsync(id);
            _context.BlogTags.Remove(blogTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogTagExists(int id)
        {
            return _context.BlogTags.Any(e => e.BlogTagId == id);
        }
    }
}
