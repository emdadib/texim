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
    }
}
