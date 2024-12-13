using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public void Execute(Guid id, ClientRequest request)
        {
            Validate(request);

            var db = new ProductClientHubDbContext();

            var entity = db.Clients.FirstOrDefault(c => c.Id == id);

            if (entity is null)
                throw new NotFoundException("Cliente não encontrado");

            entity.Name = entity.Name;
            entity.Email = entity.Email;

            db.Clients.Update(entity);
            db.SaveChanges();
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
