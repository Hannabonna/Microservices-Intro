using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using merchant_services.Infrastructure.Presistences;

namespace merchant_services.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDto>
    {
         private readonly MerchantContext _context;

         public GetMerchantsQueryHandler(MerchantContext context)
         {
             _context = context;
         }

         public async Task<GetMerchantsDto> Handle(GetMerchantsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Merchants.ToListAsync();

            return new GetMerchantsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}