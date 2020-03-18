using FluentValidation;

namespace Application.StockMovements
{
    public class StockMovementValidator
    {
        public class CreateValidator : AbstractValidator<Create.Command>
        {
            public CreateValidator()
            {
                RuleFor(x => x.ProductId).NotEmpty().WithName("Product");
                RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
                RuleFor(x => x.Type).NotEmpty();
            }
        }

        public class EditValidator : AbstractValidator<Edit.Command>
        {
            public EditValidator()
            {
                RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
                RuleFor(x => x.Type).NotEmpty();
            }
        }
    }
}