using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Application.DTOs.PostDto.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(100)
                .WithMessage("Title must not exceed 100 characters");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required")
                .MaximumLength(1000)
                .WithMessage("Content must not exceed 1000 characters");
        }
    }
}