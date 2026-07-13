using FluentValidation;

namespace InventoryPlatform.Application.Features.Inventory.RemoveStock;

public sealed class RemoveStockValidator : AbstractValidator<RemoveStockCommand>
{
    public RemoveStockValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}
