using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace texim.Areas.Admin.Models
{
    public class ProductCategoryViewModel
    {
      
        public int ProductCategoryId { get; set; }
        public Guid ProductCategoryKey { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        [StringLength(250)]
        public string SmallDetails { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }

        public int ParentCategoryId { get; set; }
        public string IconThumb { get; set; }
        public DateTime LastModified { get; set; }
        public bool Status { get; set; }
    }
}