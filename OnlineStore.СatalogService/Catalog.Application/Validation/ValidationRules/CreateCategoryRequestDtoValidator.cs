﻿using Catalog.Application.DTOs.RequestDtos.Categories;
using FluentValidation;

namespace Catalog.Application.Validation.ValidationRules
{
    public class CreateCategoryRequestDtoValidator : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestDtoValidator()
        {
            RuleFor(category => category.Title)
                .NotEmpty().MaximumLength(48);
        }
    }
}