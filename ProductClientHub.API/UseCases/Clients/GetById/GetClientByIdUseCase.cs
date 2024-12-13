using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ClientResponse Execute(Guid id)
        {
            var db = new ProductClientHubDbContext();

            var entity = db.Clients
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);

            if (entity is null)
                throw new NotFoundException("Cliente não encontrado");

            return new ClientResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Products = entity.Products.Select(p => new ProductShortResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList(),
            };
        }
    }
}
