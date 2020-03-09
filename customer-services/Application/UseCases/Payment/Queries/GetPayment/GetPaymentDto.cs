using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;

namespace customer_services.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public PaymentEn Data { get; set; }
    }
}