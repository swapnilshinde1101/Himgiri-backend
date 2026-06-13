using FluentValidation;
using Himgiri.Core.DTOs;

namespace Himgiri.Core.Validation;

public class CreateItemRequestValidator : AbstractValidator<CreateItemRequest>
{
    public CreateItemRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Item name is required.")
            .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(1000).WithMessage("Image URL cannot exceed 1000 characters.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category is required.");

        RuleFor(x => x.GradeIds)
            .NotEmpty().WithMessage("At least one Grade is required.");

        RuleFor(x => x.StockQty)
            .GreaterThanOrEqualTo(0).WithMessage("Stock Quantity cannot be negative.");

        RuleFor(x => x.TargetQty)
            .GreaterThan(0).WithMessage("Target Quantity must be greater than 0.");

        RuleFor(x => x.StorageStatus)
            .IsInEnum().WithMessage("Invalid Storage Status.");
    }
}
