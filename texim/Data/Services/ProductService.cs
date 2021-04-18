using texim.Data.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using texim.Data.DAL;
using System.Threading.Tasks;
using texim.Models;
using texim.Areas.Admin.Models;
using texim.Helper;
namespace texim.Data.Services
{
    public class ProductService
    {

        //static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());
        static IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public static async Task<IEnumerable<Product>> GetProducts()
        {
            return await unitOfWork.Repository<Product>().GetAllAsync();
        }
        public static Product GetProduct(int id)
        {
            return unitOfWork.Repository<Product>().GetById(id);
        }
        public static Product GetProductBySlug(string slug = "")
        {
            return unitOfWork.Repository<Product>().Find(x => x.Slug == slug && x.Status);
        }
        public static async Task<bool> SaveProduct(Product model)
        {
            model.ProductKey = Guid.NewGuid();
            model.CreateAt = DateTime.Now;
            model.UpdateAt = DateTime.Now;
            var result = await unitOfWork.Repository<Product>().InsertAsync(model);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> UpdateProduct(Product model)
        {
            Product product = GetProduct(model.ProductId);
            if (product == null) return false;

            product.UpdateAt = DateTime.Now;
            product.BigDetails = model.BigDetails;
            product.ProductCategoryId = model.ProductCategoryId;
            product.SmallDetails = model.SmallDetails;
            product.Status = model.Status;
            product.Title = model.Title;
            product.Slug = model.Slug;
            //SEO
            product.Keyword = model.Keyword;
            product.MetaDescription = model.MetaDescription;
            product.MetaTitle = model.MetaTitle;
            product.OgTitle = model.OgTitle;
            product.OgDescription = model.OgDescription;
            product.Canonical = model.Canonical;
            product.OgImage = !string.IsNullOrEmpty(model.OgImage) ? model.OgImage : product.OgImage;

            product.BrandId = model.BrandId;

            var result = await unitOfWork.Repository<Product>().UpdateAsync(product);
            if (result != null) return true;
            return false;
        }
        public static async Task<bool> RemoveProduct(Product model)
        {
            var productImages = await unitOfWork.Repository<ProductImage>().FindAllAsync(x => x.ProductId == model.ProductId);
            foreach (var item in productImages)
            {
                ImageService.ImageRemove(item.Image);
                ImageService.ImageRemove(item.Thumb);
            }
            var result = await unitOfWork.Repository<Product>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }
        public static async Task<ProductViewModel> GetProductDetails(int id)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);
            IEnumerable<ProductImage> productImages = await unitOfWork.Repository<ProductImage>().FindAllAsync(x => x.ProductId == product.ProductId && x.Status);
            if (product != null)
            {
                ProductViewModel productVm = new ProductViewModel
                {
                    BigDetails = product.BigDetails ?? "",

                    Keyword = product.Keyword ?? "",
                    MetaDescription = product.MetaDescription ?? "",
                    MetaTitle = product.MetaTitle ?? "",
                    OgTitle = product.OgTitle ?? "",
                    OgDescription = product.OgDescription ?? "",
                    Canonical = product.Canonical ?? "",
                    OgImage = product.OgImage ?? "",

                    ProductCategoryId = product.ProductCategoryId,
                    ProductId = product.ProductId,
                    SmallDetails = product.SmallDetails ?? "",
                    Title = product.Title ?? "",
                    Status = product.Status,

                    BrandId = product.BrandId,
                 
                    BrandName = product.BrandId != 0 ? CommonService.GetBrand(product.BrandId).Name : "",
                    ProductImages = productImages,
                    CategoryTitle  = product.ProductCategoryId != 0  ? ProductCategoryService.GetCategory(product.ProductCategoryId).CategoryName : "",
                };
                return productVm;
            }
            return new ProductViewModel();

        }
        public static List<ProductViewModel> ProductByCategory(int catId)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            List<Product> products = unitOfWork.Repository<Product>().FindAll(x => x.ProductCategoryId == catId).ToList();
            foreach (var product in products)
            {
                productList.Add(GetProductViewModel(product.ProductId));
            }

            return productList;
        }
        public static CategoryWithProducts GetCategoryWithProducts(string slug)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var category = ProductCategoryService.GetCategoryBySlug(slug);

            List<Product> products = unitOfWork.Repository<Product>().FindAll(x => x.ProductCategoryId == category.ProductCategoryId).Where(x => x.Status).ToList();
            foreach (var product in products)
            {
                productList.Add(GetProductViewModel(product.ProductId));
            }
            CategoryWithProducts cwp = new CategoryWithProducts
            {
                CategoryName = category.CategoryName,
                Slug = category.Slug,
                Keyword = category.Keyword,
                ProductCategoryId = category.ProductCategoryId,
                MetaDescription = category.MetaDescription,
                MetaTitle = category.MetaTitle,
                IconThumb = category.IconThumb,
                SmallDetails = category.SmallDetails,
                Products = productList,
                Status = category.Status
            };
            return cwp;
        }
        public static ProductViewModel GetProductViewModel(int id = 0, string slug = "", string isFav = "", string ip = "", string email = "", string phone = "")
        {
            var product = id != 0 ? GetProduct(id) : GetProductBySlug(slug);
           
         
            ProductViewModel productVm = new ProductViewModel
            {
                BigDetails = product.BigDetails,
               
                ProductCategoryId = product.ProductCategoryId,
                ProductId = product.ProductId,
                SmallDetails = product.SmallDetails,
                Title = product.Title,
                Slug = product.Slug,
                Status = product.Status,

                //Seo
                Keyword = product.Keyword ?? "",
                MetaDescription = product.MetaDescription ?? "",
                MetaTitle = product.MetaTitle ?? "",
                OgTitle = product.OgTitle ?? "",
                OgDescription = product.OgDescription ?? "",
                Canonical = product.Canonical ?? "",
                OgImage = product.OgImage ?? "",

                BrandId = product.BrandId,

                BrandName = product.BrandId != 0 ? CommonService.GetBrand(product.BrandId).Name : "",

          
                CategoryTitle = ProductCategoryService.GetCategory(product.ProductCategoryId).CategoryName ?? "",
                ProductImages = ProductImageService.ImagesByProductId(product.ProductId),

            };
            return productVm;
        }




        public static IEnumerable<ProductViewModel> ProductGallery()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var products = unitOfWork.Repository<Product>().FindAll(x => x.Status).ToList();
              foreach (var product in products)
                {
                    productList.Add(GetProductViewModel(product.ProductId));
                }
            
            return productList.OrderByDescending(x => x.PublishDate);
        }

        public static IEnumerable<ProductViewModel> ProductByParentAndChildCategory(int catId)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var cat = ProductCategoryService.GetChaildCategories(catId);
            cat.Add(ProductCategoryService.GetCategory(catId));
            foreach (var item in cat)
            {
                var products = unitOfWork.Repository<Product>().FindAll(x => x.Status && x.ProductCategoryId == item.ProductCategoryId).ToList();
                foreach (var product in products)
                {
                    productList.Add(GetProductViewModel(product.ProductId));
                }
            }
            return productList.OrderByDescending(x => x.PublishDate);
        }
    }
}