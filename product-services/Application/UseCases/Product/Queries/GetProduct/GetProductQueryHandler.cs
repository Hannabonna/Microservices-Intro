using System.Threading;
using product_services.Infrastructure.Presistences;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace product_services.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
         private readonly ProductContext _context;

         public GetProductQueryHandler(ProductContext context)
         {
             _context = context;
         }

         public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellation)
         {
             var result = await _context.Products.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetProductDto
             {
                 Success = true,
                 Message = "Product successfully retrieved",
                 Data = result
             };
         }
    }
   


}