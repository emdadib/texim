using texim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace texim.Areas.Admin.Models
{
    public class BlogViewModel
    {
       
        public int BlogId { get; set; }
        public Guid BlogKey { get; set; }
        public int BlogCategoryId { get; set; }
        [Required, StringLength(250)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Slug { get; set; }
        [StringLength(250)]
        public string SubTitle { get; set; }
        [StringLength(300)]
        public string SmallDetails { get; set; }
        public string BigDetails { get; set; }
    //    [Required]
        public string Image { get; set; }
        public string FeaturedImage { get; set; }

        [StringLength(150)]
        public string Video { get; set; }
        public bool Status { get; set; }
        [StringLength(150)]
        public string AuthorName { get; set; }
        public string AboutAuthor { get; set; }
        //
        public Nullable<DateTime> PublishDate { get; set; }

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
        public string CategoryName { get; set; }
        public string[] Tags { get; set; }
        public List<BlogTag> TagList { get; set; }


        public BlogViewModel()
        {
            PublishDate = DateTime.Now;
        }
    }
}