using FluentValidation;

namespace Application.Categories
{
    public class CategoryValidator
    {
        public class CreateValidator : AbstractValidator<Create.Command>
        {
            public CreateValidator()
            {
                RuleFor(x => x.CategoryName).NotEmpty();
            }
        }

        public class EditValidator : AbstractValidator<Edit.Command>
        {
            public EditValidator()
            {
                RuleFor(x => x.CategoryName).NotEmpty();
            }
        }
    }
}