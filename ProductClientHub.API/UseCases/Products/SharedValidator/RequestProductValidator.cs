using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<ProductRequest>
    {
        public RequestProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório");

            RuleFor(product => product.Brand)
                .NotEmpty()
                .NotNull()
                .WithMessage("A marca é obrigatória");

            RuleFor(product => product.Price)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O preço é obrigatório");
        }
    }
}
