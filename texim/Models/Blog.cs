using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public Guid BlogKey { get; set; }
        [ForeignKey("BlogCategory")]
        public int BlogCategoryId { get; set; }
        [StringLength(250), Required]
        public string Title { get; set; }
        [StringLength(250)]
        public string Slug { get; set; }
        [StringLength(250)]
        public string SubTitle { get; set; }
        [StringLength(300)]
        public string SmallDetails { get; set; }
        //[AllowHtml]-----jim
        public string BigDetails { get; set; }

        public string Image { get; set; }
        public string FeaturedImage { get; set; }

        [StringLength(150)]
        public string Video { get; set; }
        public bool Status { get; set; }
        [StringLength(150)]
        public string AuthorName { get; set; }
        public string AboutAuthor { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime PublishDate { get; set; }

        //Seo
        [Display(Name = "Meta Title"), StringLength(300)]
        public string MetaTitle { get; set; }
        [StringLength(300)]
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

        public virtual BlogCategory BlogCategory { get; set; }
    }
}
