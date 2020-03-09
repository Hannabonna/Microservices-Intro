using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;

namespace customer_services.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerDto : BaseDto
    {
        public CustomerEn Data { get; set; }
    }
}