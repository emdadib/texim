using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace texim.Areas.Admin.Models
{
    public class ProductImageViewModel
    {
        public int ProductImageId { get; set; }
        public Guid ProductImageKey { get; set; }
        public string ProductTitle { get; set; }
        public int ProductId { get; set; }
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(300)]
        public string Caption { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Image { get; set; }
        public string Thumb { get; set; }
        public DateTime LastModified { get; set; }
        public bool Status { get; set; }
    }
}