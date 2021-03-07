using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class WebBanner
    {
        public int WebBannerId { get; set; }
        [StringLength(100)]
        [Required]
        public string SmallTitle { get; set; }
        [StringLength(30)]
        [Required]
        public string BigTitleOne { get; set; }
        [StringLength(30)]
        public string BigTitleTwo { get; set; }
        [StringLength(30)]
        public string BigTitleThree { get; set; }
        [StringLength(150)]
        public string SmallDetails { get; set; }
        [StringLength(150)]

        public string LinkText { get; set; }
        [StringLength(150)]
        public string Link { get; set; }
        [StringLength(150)]
        public string Image { get; set; }
        [StringLength(150)]
        public string Thumbnail { get; set; }
        public string SlideStyle { get; set; }
        public bool Status { get; set; }
        public DateTime LastModified { get; set; }
       

        //Initial Fields
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
