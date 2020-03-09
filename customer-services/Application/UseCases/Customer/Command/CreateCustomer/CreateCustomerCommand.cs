using System;
using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;
using MediatR;

namespace customer_services.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : RequestData<CustomerEn> , IRequest<CreateCustomerCommandDto> 
    {
        
    }
}