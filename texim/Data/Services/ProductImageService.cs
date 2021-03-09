using texim.Data;
using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using texim.Areas.Admin.Models;

namespace texim.Logic.Services
{
    public class ProductImageService
    {
        

        static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public static async Task<IEnumerable<ProductImage>> GetProductImages()
        {
            return await unitOfWork.Repository<ProductImage>().GetAllAsync();
        }

        public static ProductImage GetProductImage(int id)
        {
            return unitOfWork.Repository<ProductImage>().GetById(id);
        }
        public static async Task<bool> SaveProductImage(ProductImageViewModel model)
        {

            ProductImage image = new ProductImage
            {
                Caption = model.Caption,
                Image = model.Image,
                Keyword = model.Keyword,
                LastModified = DateTime.Now,
                MetaDescription = model.MetaDescription,
                ProductId = model.ProductId,
                ProductImageKey = Guid.NewGuid(),
                Status = model.Status,
                Title = model.Title,
                Thumb = model.Thumb
            };
            var result = await unitOfWork.Repository<ProductImage>().InsertAsync(image);
            if (result != null) return true;
            return false;
        }

        public static async Task<bool> UpdateProductImage(ProductImageViewModel model)
        {
            ProductImage productImage = GetProductImage(model.ProductImageId);

            productImage.LastModified = DateTime.Now;
            productImage.Keyword = model.Keyword;
            productImage.MetaDescription = model.MetaDescription;
            productImage.Status = model.Status;
            productImage.Title = model.Title;
            productImage.Caption = model.Caption;
            productImage.Image = !string.IsNullOrEmpty(model.Image) ? model.Image : productImage.Image;
            productImage.Thumb = !string.IsNullOrEmpty(model.Thumb) ? model.Thumb : productImage.Thumb;
            productImage.ProductId = model.ProductId;

            var result = await unitOfWork.Repository<ProductImage>().UpdateAsync(productImage);
            if (result != null) return true;
            return false;
        }

        public static async Task<bool> RemoveProductImage(ProductImage model)
        {
            var result = await unitOfWork.Repository<ProductImage>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }

        public static ProductImageViewModel GetProductForImageByProductId(int productId)
        {
            var product = ProductService.GetProduct(productId);
            ProductImageViewModel productImageView = new ProductImageViewModel
            {
                ProductTitle = product.Title,
                ProductId = product.ProductId
            };
            return productImageView;
        }
        public static ProductImageViewModel GetProductImageById(int productImageId)
        {
            var productImage = GetProductImage(productImageId);
            var product = ProductService.GetProduct(productImage.ProductId);
            ProductImageViewModel productImageView = new ProductImageViewModel
            {
                ProductTitle = product.Title,
                ProductId = product.ProductId,
                Title = productImage.Title,
                Caption = productImage.Caption,
                Image = productImage.Image,
                Keyword = productImage.Keyword,
                MetaDescription = productImage.MetaDescription,
                ProductImageId = productImage.ProductImageId,
                Thumb = productImage.Thumb,
                Status = productImage.Status
            };
            return productImageView;
        }

        public static string GetProductName(int productId)
        {
            return ProductService.GetProduct(productId).Title;
        }

        public static List<ProductImage> ImagesByProductId(int productId)
        {
            return unitOfWork.Repository<ProductImage>().FindAll(x => x.ProductId == productId && x.Status).ToList() ?? new List<ProductImage>();
        }
    }
}