
using MediatR;

namespace product_services.Application.UseCases.Product.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandDto>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}