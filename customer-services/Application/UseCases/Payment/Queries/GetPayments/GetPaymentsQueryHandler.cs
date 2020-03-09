using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using customer_services.Infrastructure.Presistences;

namespace customer_services.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, GetPaymentsDto>
    {
         private readonly CustomerContext _context;

         public GetPaymentsQueryHandler(CustomerContext context)
         {
             _context = context;
         }

         public async Task<GetPaymentsDto> Handle(GetPaymentsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Payments.ToListAsync();

            return new GetPaymentsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}