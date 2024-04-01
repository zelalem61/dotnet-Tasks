using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Blog;

using Application.Common.DTOs.Blog;
using Application.Contracts.Persistence;

namespace Application.Common.DTOs.Blog.Validators;

public class IBlogDtoValidator : AbstractValidator<IBlogDTO>
{

    public IBlogDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 100 characters.");

        RuleFor(p => p.Content)
            .NotEmpty().WithMessage("{PropertyName} is required.");
        
    }

  
}

