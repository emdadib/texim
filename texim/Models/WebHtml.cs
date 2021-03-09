using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class WebHtml
    {
        public int WebHtmlId { get; set; }
        [StringLength(30)]
        public string Identifier { get; set; }
        [StringLength(250)]
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        [Required]
        public string SmallDetailsOne { get; set; }
        public string SmallDetailsTwo { get; set; }
        //[AllowHtml]-----jim
        public string BigDetailsOne { get; set; }
        //[AllowHtml]-----jim
        public string BigDetailsTwo { get; set; }

        public string PictureOne { get; set; }

        public string PictureTwo { get; set; }

        public string PictureThree { get; set; }
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
