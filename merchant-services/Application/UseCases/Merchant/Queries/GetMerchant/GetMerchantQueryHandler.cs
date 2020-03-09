using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using merchant_services.Application.Interfaces;
using merchant_services.Infrastructure.Presistences;

namespace merchant_services.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
         private readonly MerchantContext _context;

         public GetMerchantQueryHandler(MerchantContext context)
         {
             _context = context;
         }

         public async Task<GetMerchantDto> Handle(GetMerchantQuery request, CancellationToken cancellation)
         {
             var result = await _context.Merchants.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetMerchantDto
             {
                 Success = true,
                 Message = "Merchant successfully retrieved",
                 Data = result
             };
         }
    }
   


}