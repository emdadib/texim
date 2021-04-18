using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace texim.Data.Services
{
    public class ProductCategoryService
    {
        // static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());
        static IUnitOfWork unitOfWork;
        public ProductCategoryService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public static async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            return await unitOfWork.Repository<ProductCategory>().GetAllAsync();
        }
        public static ProductCategory GetCategory(int id)
        {
            return unitOfWork.Repository<ProductCategory>().GetById(id);
        }
        public static async Task<bool> SaveProductCategory(ProductCategory model)
        {
            model.ProductCategoryKey = Guid.NewGuid();
            model.LastModified = DateTime.Now;
            var result = await unitOfWork.Repository<ProductCategory>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> UpdateProductCategory(ProductCategory model)
        {
            ProductCategory category = GetCategory(model.ProductCategoryId);

            category.LastModified = DateTime.Now;
            category.CategoryName = model.CategoryName;
            category.IconThumb = !string.IsNullOrEmpty(model.IconThumb) ? model.IconThumb : category.IconThumb;

            category.Canonical = model.Canonical;
            category.Keyword = model.Keyword;
            category.MetaDescription = model.MetaDescription;
            category.MetaTitle = model.MetaTitle;
            category.OgDescription = model.OgDescription;
            category.OgImage = !string.IsNullOrEmpty(model.OgImage) ? model.OgImage : category.OgImage;
            category.OgTitle = model.OgTitle;

            category.ParentCategoryId = model.ParentCategoryId;
            category.SmallDetails = model.SmallDetails;
            category.Status = model.Status;
            category.Slug = model.Slug;

            var result = await unitOfWork.Repository<ProductCategory>().UpdateAsync(category);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> RemoveProductCategory(ProductCategory model)
        {
            var result = await unitOfWork.Repository<ProductCategory>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }
        //Category dropdown
        public static IList<SelectListItem> GetProductCategories(int? id = 0)
        {
            var category =  unitOfWork.Repository<ProductCategory>().GetAll().Select(cat =>
                           new SelectListItem
                           {
                               Text = cat.CategoryName,
                               Value = cat.ProductCategoryId.ToString(),
                               Selected = cat.ProductCategoryId == id ? true : false
                           }).ToList();

            category.Insert(0, new SelectListItem { Text = "Select Category", Value = "0" });
            return category;
        }

        public static List<ProductCategory> GetParentCategory()
        {
            return unitOfWork.Repository<ProductCategory>().FindAll(x => x.ParentCategoryId == 0).ToList();
        }
        public static ProductCategory GetCategoryBySlug(string slug)
        {
            return unitOfWork.Repository<ProductCategory>().Find(x => x.Slug == slug);
        }

        public static List<ProductCategory> GetChaildCategories(int parentCatId)
        {
            return unitOfWork.Repository<ProductCategory>().FindAll(x => x.ParentCategoryId == parentCatId).ToList();
        }

    }
}