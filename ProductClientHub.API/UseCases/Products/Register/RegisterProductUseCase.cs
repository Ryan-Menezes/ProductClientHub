using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Products.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ProductShortResponse Execute(Guid clientId, ProductRequest request)
        {
            var db = new ProductClientHubDbContext();

            Validate(db, clientId, request);

            var entity = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId,
            };

            db.Products.Add(entity);
            db.SaveChanges();

            return new ProductShortResponse
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(ProductClientHubDbContext db, Guid clientId, ProductRequest request)
        {
            var exists = db.Clients.Any(c => c.Id == clientId);

            if (exists == false)
                throw new NotFoundException("Cliente não encontrado");

            var validator = new RequestProductValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
