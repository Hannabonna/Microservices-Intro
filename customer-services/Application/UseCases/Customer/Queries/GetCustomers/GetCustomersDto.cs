using System.Collections.Generic;
using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;

namespace customer_services.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public IList<CustomerEn> Data { get; set; }
    }
}