using FluentValidation;
using Shopbridge_base.Infrastructure.Language;
using Shopbridge_base.Infrastructure.Models;

namespace Shopbridge_base.Application.Contract
{
    public class PutProductValidator : AbstractValidator<ProductModel>
    {
        public PutProductValidator() 
        {
            When(x => x == null, () =>
            {
                RuleFor(x => x).NotNull();
            }).Otherwise(() =>
            {
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(Message.InvalidField.ToMessage() + " from Product Name").MaximumLength(30);
            });
        }
    }
}
