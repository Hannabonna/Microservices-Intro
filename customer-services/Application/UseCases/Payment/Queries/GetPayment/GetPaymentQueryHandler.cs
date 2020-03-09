using System.Threading;
using customer_services.Infrastructure.Presistences;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace customer_services.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentDto>
    {
         private readonly CustomerContext _context;

         public GetPaymentQueryHandler(CustomerContext context)
         {
             _context = context;
         }

         public async Task<GetPaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellation)
         {
             var result = await _context.Payments.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetPaymentDto
             {
                 Success = true,
                 Message = "Payment successfully retrieved",
                 Data = result
             };
         }
    }
   


}