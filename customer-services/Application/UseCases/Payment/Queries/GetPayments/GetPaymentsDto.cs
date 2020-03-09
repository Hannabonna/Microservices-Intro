using System.Collections.Generic;
using customer_services.Application.Models.Query;
using customer_services.Domain.Entities;

namespace customer_services.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<PaymentEn> Data { get; set; }
    }
}