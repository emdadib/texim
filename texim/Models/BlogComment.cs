using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class BlogComment
    {
        public int BlogCommentId { get; set; }
        public long BlogId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime LastModified { get; set; }
    }
}
