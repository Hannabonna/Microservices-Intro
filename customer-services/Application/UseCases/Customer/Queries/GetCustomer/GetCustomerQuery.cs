using MediatR;
using customer_services.Domain.Entities;

namespace customer_services.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerDto>
    {
        public int Id { get; set; }

        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }
}