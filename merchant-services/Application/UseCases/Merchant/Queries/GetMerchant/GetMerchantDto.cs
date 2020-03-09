using merchant_services.Application.Models.Query;
using merchant_services.Domain.Entities;

namespace merchant_services.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantDto : BaseDto
    {
        public MerchantEn Data { get; set; }
    }
}