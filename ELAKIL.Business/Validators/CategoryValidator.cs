using ELAKIL.Business.Entities;
using FluentValidation;

namespace ELAKIL.Business.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}