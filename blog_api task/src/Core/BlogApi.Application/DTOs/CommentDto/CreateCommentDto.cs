using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Application.DTOs.CommentDto
{
    public class CreateCommentDto : BaseDTO
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}