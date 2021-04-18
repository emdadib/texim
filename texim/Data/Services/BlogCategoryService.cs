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
using texim.Helper;

namespace texim.Data.Services
{
    public class BlogCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public BlogCategoryService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<IEnumerable<BlogCategory>> GetCategories() => await unitOfWork.Repository<BlogCategory>().GetAllAsync();

        public IEnumerable<BlogCategory> GetCategoryList()
        {
            return unitOfWork.Repository<BlogCategory>().GetAll();
        }
        public BlogCategory GetCategory(int id)
        {
            return unitOfWork.Repository<BlogCategory>().GetById(id);
        }
        public async Task<bool> SaveBlogCategory(BlogCategory model)
        {
           // IUnitOfWork unitOfWork = new UnitOfWork();
            model.Slug = SlugHelper.GetEncodedTitle(model.CategoryName);
            model.IsDelete = false;
            model.LastModified = DateTime.Now;

            var result = await unitOfWork.Repository<BlogCategory>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }
        public async Task<bool> UpdateBlogCategory(BlogCategory model)
        {
            BlogCategory category = GetCategory(model.BlogCategoryId);

            category.LastModified = DateTime.Now;
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
        public async Task<bool> RemoveBlogCategory(BlogCategory model)
        {
            var result = await unitOfWork.Repository<BlogCategory>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }
        //Category dropdown
        public IList<SelectListItem> GetBlogCategories(int? id = 0)
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

       
        public BlogCategory GetCategoryBySlug(string slug)
        {
            return unitOfWork.Repository<BlogCategory>().Find(x => x.Slug == slug);
        }

    

    }
}