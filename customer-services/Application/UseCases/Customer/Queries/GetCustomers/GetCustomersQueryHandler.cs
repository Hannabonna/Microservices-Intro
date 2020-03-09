using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using customer_services.Infrastructure.Presistences;

namespace customer_services.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
         private readonly CustomerContext _context;

         public GetCustomersQueryHandler(CustomerContext context)
         {
             _context = context;
         }

         public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellation)
         {
            var data = await _context.Customers.ToListAsync();

            return new GetCustomersDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}