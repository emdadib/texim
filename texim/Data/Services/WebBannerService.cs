using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace texim.Data.Services
{
    public class WebBannerService
    {
        // static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());
        public static IUnitOfWork unitOfWork;
        public WebBannerService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public static async Task<IEnumerable<WebBanner>> GetBannerAsync()
        {
            return await unitOfWork.Repository<WebBanner>().GetAllAsync();
        }


        public static IEnumerable<WebBanner> GetBanners()
        {
            return unitOfWork.Repository<WebBanner>().GetAll();
        }
        public static WebBanner GetWebBanner(int id)
        {
            return unitOfWork.Repository<WebBanner>().GetById(id);
        }
        public static async Task<bool> SaveWebBanner(WebBanner model)
        {
            model.UpdateAt = DateTime.Now;
            model.CreateAt = DateTime.Now;
            var result = await unitOfWork.Repository<WebBanner>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }

        public static async Task<bool> UpdateWebBanner(WebBanner model)
        {
            WebBanner webBanner = GetWebBanner(model.WebBannerId);

            webBanner.UpdateAt = DateTime.Now;
            webBanner.SlideStyle = model.SlideStyle;
            webBanner.BigTitleOne = model.BigTitleOne;
            webBanner.BigTitleTwo = model.BigTitleTwo;
            webBanner.BigTitleThree = model.BigTitleThree;
            webBanner.SmallDetails = model.SmallDetails;
            webBanner.SmallTitle = model.SmallTitle;
            webBanner.Image = !string.IsNullOrEmpty(model.Image) ? model.Image : webBanner.Image;
            webBanner.Thumbnail = !string.IsNullOrEmpty(model.Thumbnail) ? model.Thumbnail : webBanner.Thumbnail;
            webBanner.LinkText = model.LinkText;
            webBanner.Link = model.Link;
            webBanner.Status = model.Status;

            var result = await unitOfWork.Repository<WebBanner>().UpdateAsync(webBanner);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> RemoveWebBanner(WebBanner model)
        {
            var result = await unitOfWork.Repository<WebBanner>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }
    }
}