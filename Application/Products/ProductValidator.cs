using FluentValidation;

namespace Application.Products
{
    public class ProductValidator
    {
        public class CreateValidator : AbstractValidator<Create.Command>
        {
            public CreateValidator()
            {
                RuleFor(x => x.CategoryId).NotEmpty().WithName("Category");
                RuleFor(x => x.StoreId).NotEmpty().WithName("Store");
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.QuantityPerUnit).NotEmpty();
                RuleFor(x => x.UnitPrice).NotEmpty().GreaterThan(0);
            }
        }

        public class EditValidator : AbstractValidator<Edit.Command>
        {
            public EditValidator()
            {               
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.QuantityPerUnit).NotEmpty();
                RuleFor(x => x.UnitPrice).NotEmpty().GreaterThan(0);
            }
        }
    }
}