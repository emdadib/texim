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
    public class WebHtmlService
    {


        //static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());
        static IUnitOfWork unitOfWork;
        public WebHtmlService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public static async Task<IEnumerable<WebHtml>> GetHtmls()
        {
            return await unitOfWork.Repository<WebHtml>().GetAllAsync();
        }

        public static WebHtml GetWebHtml(int id)
        {
            var html = unitOfWork.Repository<WebHtml>().GetById(id);
            
            return html;
        }
        public static async Task<bool> SaveWebHtml(WebHtml model)
        {
            model.UpdateAt = DateTime.Now;
            var result = await unitOfWork.Repository<WebHtml>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }

        public static async Task<bool> UpdateWebHtml(WebHtml model)
        {
            WebHtml webHtml  = GetWebHtml(model.WebHtmlId);

            webHtml.UpdateAt = DateTime.Now;
            webHtml.BigDetailsOne = model.BigDetailsOne;
            webHtml.BigDetailsTwo = model.BigDetailsTwo;
            webHtml.PictureOne = !string.IsNullOrEmpty(model.PictureOne) ? model.PictureOne  : webHtml.PictureOne;
            webHtml.PictureTwo = !string.IsNullOrEmpty(model.PictureTwo) ? model.PictureTwo : webHtml.PictureTwo;
            webHtml.PictureThree = !string.IsNullOrEmpty(model.PictureThree) ? model.PictureThree : webHtml.PictureThree;
            webHtml.SmallDetailsOne = model.SmallDetailsOne;
            webHtml.SmallDetailsTwo = model.SmallDetailsTwo;
            webHtml.SubTitle = model.SubTitle;
            webHtml.Title = model.Title;
            webHtml.Status = model.Status;

            var result = await unitOfWork.Repository<WebHtml>().UpdateAsync(webHtml);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> RemoveWebHtml(WebHtml model)
        {
            var result = await unitOfWork.Repository<WebHtml>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }

        public static WebHtml GetContentByIdentifire(string identifire)
        {
            return unitOfWork.Repository<WebHtml>().Find(x => x.Identifier == identifire);
        }

        public static IEnumerable<WebHtml> GetContentListByIdentifire(string identifire)
        {
            return unitOfWork.Repository<WebHtml>().FindAll(x => x.Identifier == identifire);
        }

    }
}