using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public Guid PortfolioKey { get; set; }
        public string Title { get; set; }
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
