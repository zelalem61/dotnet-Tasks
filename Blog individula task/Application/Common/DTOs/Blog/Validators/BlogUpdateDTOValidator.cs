using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Blog;

using Application.Contracts.Persistence;

namespace Application.Common.DTOs.Blog.Validators;

public class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDTO>
{

    public  UpdateBlogDtoValidator()
    {
        Include(new IBlogDtoValidator());
    }
}

