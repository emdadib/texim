using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public Guid ProductCategoryKey { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        [StringLength(250)]
        public string SmallDetails { get; set; }
        [StringLength(300)]
        public string Keyword { get; set; }
        [StringLength(500)]
        public string MetaDescription { get; set; }
        [StringLength(150)]
        public string MetaTitle { get; set; }
        [StringLength(150)]
        public string OgTitle { get; set; }
        [Display(Name = "OG:Description"), StringLength(500)]
        public string OgDescription { get; set; }

        [Display(Name = "OG:Image")]
        public string OgImage { get; set; }
        [StringLength(150)]
        public string Canonical { get; set; }

        public int ParentCategoryId { get; set; }
        public string IconThumb { get; set; }
        public DateTime LastModified { get; set; }
        public bool Status { get; set; }
    }
}
