using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid id)
        {
            var db = new ProductClientHubDbContext();

            var entity = db.Clients.FirstOrDefault(c => c.Id == id);

            if (entity is null)
                throw new NotFoundException("Cliente não encontrado");

            db.Clients.Remove(entity);
            db.SaveChanges();
        }
    }
}
