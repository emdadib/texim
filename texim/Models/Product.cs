using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey("ProductCategory")]
        [Display(Name = "Product Category")]
        [Required]
        public int ProductCategoryId { get; set; }

        public Guid ProductKey { get; set; }
        [StringLength(250)]
        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }
        [StringLength(350)]
        [Display(Name = "Small Details")]
        [Required]
        public string SmallDetails { get; set; }
        //[AllowHtml]-----jim
        [Display(Name = "Details")]
        public string BigDetails { get; set; }

        //SEO

        [Display(Name = "Meta Title"), StringLength(300)]
        public string MetaTitle { get; set; }
        [Required, StringLength(300)]
        public string Keyword { get; set; }
        [Display(Name = "Meta Description"), StringLength(500)]
        public string MetaDescription { get; set; }
        [Display(Name = "OG:Title"), StringLength(300)]
        public string OgTitle { get; set; }

        [Display(Name = "OG:Description"), StringLength(500)]
        public string OgDescription { get; set; }

        [Display(Name = "OG:Image")]
        public string OgImage { get; set; }
        [StringLength(150)]
        public string Canonical { get; set; }


        public bool Status { get; set; }
        public int BrandId { get; set; }

        //Initial Fields
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDelete { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

    }
}
