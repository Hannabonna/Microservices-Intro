
using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;
using MediatR;

namespace customer_services.Application.UseCases.Payment.Command.UpdatePayment
{
    public class UpdatePaymentCommand : RequestData<PaymentEn>,IRequest<UpdatePaymentCommandDto>
    {
        
    }
}