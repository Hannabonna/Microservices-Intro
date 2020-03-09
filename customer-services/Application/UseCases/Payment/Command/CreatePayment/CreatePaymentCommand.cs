using System;
using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;
using MediatR;

namespace customer_services.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommand : RequestData<PaymentEn> , IRequest<CreatePaymentCommandDto>
    {
        
    }
}