using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace texim.Areas.Admin.Models
{
    public class CategoryWithProducts
    {
        public int ProductCategoryId { get; set; }
        public Guid ProductCategoryKey { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public string SmallDetails { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }

        public int ParentCategoryId { get; set; }
        public string IconThumb { get; set; }
        public DateTime LastModified { get; set; }
        public bool Status { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}