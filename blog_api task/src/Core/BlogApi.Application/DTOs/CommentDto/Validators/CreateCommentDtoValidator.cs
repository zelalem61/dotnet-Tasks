using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Application.DTOs.CommentDto.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required")
                .MaximumLength(1000)
                .WithMessage("Content must not exceed 1000 characters");
        }
    }
}