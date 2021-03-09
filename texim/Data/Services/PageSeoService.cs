using texim.Data;
using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace texim.Logic.Services
{
    public class PageSeoService
    {
        static IUnitOfWork unitOfWork = new UnitOfWork(new AspNetHostingPermissionLevel());
        public static async Task<IEnumerable<PageSeo>> GetPageSeoAsync()
        {
            return await unitOfWork.Repository<PageSeo>().GetAllAsync();
        }


        public static IEnumerable<PageSeo> GetPageSeo()
        {
            return unitOfWork.Repository<PageSeo>().GetAll();
        }
        public static PageSeo GetPageSeo(int id)
        {
            return unitOfWork.Repository<PageSeo>().GetById(id);
        }

        public static PageSeo GetPageSeoByUrl(string url = "")
        {
            return unitOfWork.Repository<PageSeo>().Find(x => x.PageUrl.Equals(url));
        }
        public static async Task<bool> SavePageSeo(PageSeo model)
        {
            model.LastModified = DateTime.Now;
            var result = await unitOfWork.Repository<PageSeo>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }

        public static async Task<bool> UpdatePageSeo(PageSeo model)
        {
            PageSeo pageSeo = GetPageSeo(model.PageSeoId);

            pageSeo.LastModified = DateTime.Now;
            pageSeo.PageUrl = model.PageUrl;
            pageSeo.Canonical = model.Canonical;
            pageSeo.Keyword = model.Keyword;
            pageSeo.MetaDescription = model.MetaDescription;
            pageSeo.MetaTitle = model.MetaTitle;
            pageSeo.OgDescription = model.OgDescription;
            pageSeo.OgImage = !string.IsNullOrEmpty(model.OgImage) ? model.OgImage : pageSeo.OgImage;
            pageSeo.OgTitle = model.OgTitle;
            pageSeo.Status = model.Status;

            var result = await unitOfWork.Repository<PageSeo>().UpdateAsync(pageSeo);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> RemovePageSeo(PageSeo model)
        {
            var result = await unitOfWork.Repository<PageSeo>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }
    }
}