
using merchant_services.Application.Models.Query;
using merchant_services.Domain.Entities;
using MediatR;

namespace merchant_services.Application.UseCases.Merchant.Command.UpdateMerchant
{
    public class UpdateMerchantCommand : RequestData<MerchantEn>, IRequest<UpdateMerchantCommandDto>
    {
        
    }
}