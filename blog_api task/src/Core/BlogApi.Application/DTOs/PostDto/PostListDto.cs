using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Application.DTOs.PostDto
{
    public class PostListDto : BaseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
    }
}