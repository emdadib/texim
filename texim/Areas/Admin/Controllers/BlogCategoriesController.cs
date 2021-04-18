using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using texim.Data;
using texim.Data.IDAL;
using texim.Data.Services;
using texim.Helper;
using texim.Models;

namespace texim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/blog/category/")]
    public class BlogCategoriesController : Controller
    {
      //  private readonly BlogCategoryService _blogCategoryService;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly BlogCategoryService blogCategoryService;
        public BlogCategoriesController(/*BlogCategoryService blogCategoryService,*/ IWebHostEnvironment hostingEnv, BlogCategoryService _blogCategoryService )
        {
            //_blogCategoryService =  blogCategoryService;
            _hostingEnv = hostingEnv;
            blogCategoryService = _blogCategoryService;
        }

        // GET: Admin/BlogCategories
        [Route("categories")]
        public async Task<IActionResult> Index()
        {
            return View(await blogCategoryService.GetCategories());
        }

        // GET: Admin/BlogCategories/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var blogCategory = blogCategoryService.GetCategory(id.Value);
            if (blogCategory == null)
            {
                return NotFound();
            }

            return View(blogCategory);
        }

        // GET: Admin/BlogCategories/Create
        [Route("create"), HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCategory model)
        {
            if (ModelState.IsValid)
            {
                var seoImage = "";
                if (Request.Form.Files.Count > 0)
                {
                    var image = Request.Form.Files[0];
                    if (image.Length > 0)
                    {
                        if (ImageService.HasImageExtension(image.FileName)) seoImage = await ImageService.ImageSave(image, _hostingEnv.WebRootPath);
                        else { ViewBag.Error = "Image format not supported"; return View(model); }
                    }
                }

                model.OgImage = seoImage;
                //model.Slug = SlugHelper.GetEncodedTitle(model.CategoryName);
                //model.IsDelete = false;
                //model.LastModified = DateTime.Now;
                

                //var result = await unitOfWork.Repository<BlogCategory>().InsertAsync(model);
                var result = await blogCategoryService.SaveBlogCategory(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    return View(model);
                }
            }

            return View(model);
        }

        // GET: Admin/BlogCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogCategory = blogCategoryService.GetCategory(id.Value);
            if (blogCategory == null)
            {
                return NotFound();
            }
            return View(blogCategory);
        }

        // POST: Admin/BlogCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogCategory blogCategory)
        {
            if (id != blogCategory.BlogCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await blogCategoryService.UpdateBlogCategory(blogCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(blogCategory);
        }

        // GET: Admin/BlogCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogCategory category = blogCategoryService.GetCategory(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/BlogCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {

                BlogCategory category = blogCategoryService.GetCategory(id);
                if (category != null)
                {
                    ImageService.ImageRemove(category.OgImage);
                    var result = await blogCategoryService.RemoveBlogCategory(category);
                    return RedirectToAction("Index");
                }
                else
                {

                    return View(category);
                }
            }
            return View();
        }


    }
}
