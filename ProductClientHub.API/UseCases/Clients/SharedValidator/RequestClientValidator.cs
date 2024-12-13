using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SharedValidator
{
    public class RequestClientValidator : AbstractValidator<ClientRequest>
    {
        public RequestClientValidator()
        {
            RuleFor(client => client.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório");

            RuleFor(client => client.Email)
                .EmailAddress()
                .WithMessage("O email deve ser válido");
        }
    }
}
