using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetAll
{
    public class GetAllClientsUseCase
    {
        public AllClientsResponse Execute()
        {
            var db = new ProductClientHubDbContext();

            var clients = db.Clients.ToList();

            return new AllClientsResponse
            { 
                Clients = clients.Select(client => new ClientShortResponse
                {
                    Id = client.Id,
                    Name = client.Name,
                }).ToList(),
            };
        }
    }
}
