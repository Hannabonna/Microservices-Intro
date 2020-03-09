using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using product_services.Infrastructure.Presistences;

namespace product_services.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDto>
    {
         private readonly ProductContext _context;

         public GetProductsQueryHandler(ProductContext context)
         {
             _context = context;
         }

         public async Task<GetProductsDto> Handle(GetProductsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Products.ToListAsync();

            return new GetProductsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}