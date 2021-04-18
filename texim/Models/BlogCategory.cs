using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        [StringLength(200)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string Slug { get; set; }
        public bool Status { get; set; }

        //Initial Fields
        public DateTime LastModified { get; set; }
        public bool IsDelete { get; set; }

        //SEo
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
    }
}
