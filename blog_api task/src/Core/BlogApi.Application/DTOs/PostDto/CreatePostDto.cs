using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Application.DTOs.PostDto
{
    public class CreatePostDto : BaseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}