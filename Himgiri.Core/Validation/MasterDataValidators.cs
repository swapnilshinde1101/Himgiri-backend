using FluentValidation;
using Himgiri.Core.DTOs;

namespace Himgiri.Core.Validation;

public class GradeDtoValidator : AbstractValidator<GradeDto>
{
    public GradeDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ShortName).NotEmpty().MaximumLength(10);
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0)
            .WithMessage("Display Order cannot be negative.");
    }
}

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.HsnCode).NotEmpty().MaximumLength(20);
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0)
            .WithMessage("Display Order cannot be negative.");
        RuleFor(x => x.GstPercent).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
    }
}
