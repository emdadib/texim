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

namespace texim.Data.Services
{
    public class CommonService
    {
        //    static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());
        static IUnitOfWork unitOfWork;
        public CommonService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        //Save visitor requested Appointment

        public static IEnumerable<Brand> GetBrands()
        {
          return unitOfWork.Repository<Brand>().GetAll();
        }

        public static async Task<bool> SaveBrand(Brand model)
        {
            bool result = false;
            model.BrandKey = Guid.NewGuid();
            var save =await unitOfWork.Repository<Brand>().InsertAsync(model);
            return save != null ? result = true : result;
        }

        public static async Task<bool> EditBrand(Brand model)
        {
            var brand = unitOfWork.Repository<Brand>().GetById(model.BrandId);
            brand.Name = model.Name;
            brand.Type = model.Type;
            brand.Description = model.Description;
            brand.Logo = !string.IsNullOrEmpty(model.Logo) ? model.Logo : brand.Logo;
            await unitOfWork.Repository<Brand>().UpdateAsync(brand);
            return true;
        }

        public static Brand GetBrand(int id)
        {
           return unitOfWork.Repository<Brand>().GetById(id);
        }

        //Brand dropdown
        public static IList<SelectListItem> GetBrandDropdown(int? id = 0)
        {
            var brand = unitOfWork.Repository<Brand>().GetAll().Select(cat =>
                          new SelectListItem
                          {
                              Text = cat.Name,
                              Value = cat.BrandId.ToString(),
                              Selected = cat.BrandId == id ? true : false
                          }).ToList();

            brand.Insert(0, new SelectListItem { Text = "Select Brand", Value = "0" });
            return brand;
        }
    }
}