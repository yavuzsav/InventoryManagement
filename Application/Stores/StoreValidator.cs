using FluentValidation;

namespace Application.Stores
{
    public class StoreValidator
    {
        public class CreateValidator : AbstractValidator<Create.Command>
        {
            public CreateValidator()
            {
                RuleFor(x => x.Name).NotEmpty();               
            }
        }

        public class EditValidator : AbstractValidator<Edit.Command>
        {
            public EditValidator()
            {
                RuleFor(x => x.Name).NotEmpty();               
            }
        }
    }
}