using System;
using merchant_services.Application.Models.Query;
using merchant_services.Domain.Entities;
using MediatR;

namespace merchant_services.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommand : RequestData<MerchantEn> , IRequest<CreateMerchantCommandDto>
    {
        
    }
}