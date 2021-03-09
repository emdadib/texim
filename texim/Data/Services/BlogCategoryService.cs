using texim.Data;
using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace texim.Logic.Services
{
    public class BlogCategoryService
    {
        static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public static async Task<IEnumerable<BlogCategory>> GetCategories()
        {
            return await unitOfWork.Repository<BlogCategory>().GetAllAsync();
        }

        public static IEnumerable<BlogCategory> GetCategoryList()
        {
            return unitOfWork.Repository<BlogCategory>().GetAll();
        }
        public static BlogCategory GetCategory(int id)
        {
            return unitOfWork.Repository<BlogCategory>().GetById(id);
        }
        public static async Task<bool> SaveBlogCategory(BlogCategory model)
        {
            model.UpdateAt = DateTime.Now;
            var result = await unitOfWork.Repository<BlogCategory>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> UpdateBlogCategory(BlogCategory model)
        {
            BlogCategory category = GetCategory(model.BlogCategoryId);

            category.UpdateAt = DateTime.Now;
            category.CategoryName = model.CategoryName;
            category.Canonical = model.Canonical;
            category.Keyword = model.Keyword;
            category.MetaDescription = model.MetaDescription;
            category.MetaTitle = model.MetaTitle;
            category.OgDescription = model.OgDescription;
            category.OgImage = !string.IsNullOrEmpty(model.OgImage) ? model.OgImage : category.OgImage;
            category.OgTitle = model.OgTitle;

            category.Status = model.Status;
            category.Slug = model.Slug;

            var result = await unitOfWork.Repository<BlogCategory>().UpdateAsync(category);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> RemoveBlogCategory(BlogCategory model)
        {
            var result = await unitOfWork.Repository<BlogCategory>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }
        //Category dropdown
        public static IList<SelectListItem> GetBlogCategories(int? id = 0)
        {
            var category = unitOfWork.Repository<BlogCategory>().GetAll().Select(cat =>
                          new SelectListItem
                          {
                              Text = cat.CategoryName,
                              Value = cat.BlogCategoryId.ToString(),
                              Selected = cat.BlogCategoryId == id ? true : false
                          }).ToList();

            category.Insert(0, new SelectListItem { Text = "Select Category", Value = "0" });
            return category;
        }

       
        public static BlogCategory GetCategoryBySlug(string slug)
        {
            return unitOfWork.Repository<BlogCategory>().Find(x => x.Slug == slug);
        }

    

    }
}