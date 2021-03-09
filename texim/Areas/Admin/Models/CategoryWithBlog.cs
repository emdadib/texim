using texim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace texim.Areas.Admin.Models
{
    public class CategoryWithBlog
    {

        public int BlogCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public string MetaTitle { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImage { get; set; }
        public string Canonical { get; set; }
        public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}