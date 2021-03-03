using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public Guid ProductImageKey { get; set; }
        [ForeignKey("Product")]
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
        public virtual Product Product { get; set; }
    }
}
