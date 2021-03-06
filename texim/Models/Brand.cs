using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public Guid BrandKey { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        //Initial Fields
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool IsDelete { get; set; }

        //SEO Fields
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
    }
}
