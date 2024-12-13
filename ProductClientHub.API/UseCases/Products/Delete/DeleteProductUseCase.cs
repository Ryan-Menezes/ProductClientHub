using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
            var db = new ProductClientHubDbContext();

            var entity = db.Products.FirstOrDefault(p => p.Id == id);

            if (entity is null)
                throw new NotFoundException("Produto não encontrado");

            db.Products.Remove(entity);
            db.SaveChanges();
        }
    }
}
