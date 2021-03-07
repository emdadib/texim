﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class BlogTag
    {
        [Key]
        public int BlogTagId { get; set; }
        public int BlogId { get; set; }
        [StringLength(100)]
        public string TagName { get; set; }
        public string Slug { get; set; }

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
