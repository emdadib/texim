using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace texim.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductLabelId { get; set; }
        public Guid ProductKey { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string CategoryTitle { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string SmallDetails { get; set; }
        public string BigDetails { get; set; }
        //SEO
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImage { get; set; }
        public string Canonical { get; set; }

        //
        public bool Status { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        //

        //Product React
        public int ProductReactId { get; set; }
        public bool Favourite { get; set; }
        public int FavouriteCount { get; set; }
        public double FavouriteScoure { get; set; }

        public IEnumerable<ProductImage> ProductImages { get; set; }
    }
}