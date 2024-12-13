using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Products.Delete;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId}")]
        [ProducesResponseType(typeof(ProductShortResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromRoute] Guid clientId, [FromBody] ProductRequest request)
        {
            var useCase = new RegisterProductUseCase();

            var response = useCase.Execute(clientId, request);

            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteProductUseCase();

            useCase.Execute(id);

            return NoContent();
        }
    }
}
