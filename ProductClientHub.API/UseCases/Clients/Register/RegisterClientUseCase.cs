using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ClientResponse Execute(ClientRequest request)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ClientResponse();
        }
    }
}
