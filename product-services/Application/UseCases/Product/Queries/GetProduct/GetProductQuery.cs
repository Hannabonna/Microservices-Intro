using MediatR;

namespace product_services.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int Id { get; set; }
        
        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}