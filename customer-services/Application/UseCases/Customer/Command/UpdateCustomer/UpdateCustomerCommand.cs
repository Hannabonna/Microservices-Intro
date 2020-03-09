
using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;
using MediatR;

namespace customer_services.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : RequestData<CustomerEn>,IRequest<UpdateCustomerCommandDto>
    {
        
    }
}