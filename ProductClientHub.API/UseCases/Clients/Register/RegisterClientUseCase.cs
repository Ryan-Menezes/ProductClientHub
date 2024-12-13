using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ClientShortResponse Execute(ClientRequest request)
        {
            Validate(request);

            var db = new ProductClientHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email,
            };

            db.Clients.Add(entity);
            db.SaveChanges();

            return new ClientShortResponse
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(ClientRequest request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
