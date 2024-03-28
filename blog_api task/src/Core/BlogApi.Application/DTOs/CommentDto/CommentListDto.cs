using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Application.DTOs.CommentDto
{
    public class CommentListDto : BaseDTO
    {
        public string Content { get; set; }
        public string AuthorName { get; set; }
    }
}