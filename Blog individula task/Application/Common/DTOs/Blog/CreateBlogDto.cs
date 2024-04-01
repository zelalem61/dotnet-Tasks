using System;
using System.Collections.Generic;
using Application.Common.DTOs.Common;

namespace Application.Common.DTOs.Blog;

public class CreateBlogDTO : IBlogDTO
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? TagId { get; set; } 
        // public Tag Tag { get; set; }
    }

