using System.Collections.Generic;
using merchant_services.Application.Models.Query;
using merchant_services.Domain.Entities;

namespace merchant_services.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsDto : BaseDto
    {
        public IList<MerchantEn> Data { get; set; }
    }
}