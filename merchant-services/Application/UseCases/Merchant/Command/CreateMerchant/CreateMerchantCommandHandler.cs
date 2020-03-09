using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using merchant_services.Infrastructure.Presistences;

namespace merchant_services.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, CreateMerchantCommandDto>
    {
        private readonly MerchantContext _context;

        public CreateMerchantCommandHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<CreateMerchantCommandDto> Handle(CreateMerchantCommand request, CancellationToken cancellation)
        {
            var merchant = new Domain.Entities.MerchantEn
            {
                Name = request.DataD.Attributes.Name,
                Imamge = request.DataD.Attributes.Imamge,
                Address = request.DataD.Attributes.Address,
                Rating = request.DataD.Attributes.Rating
            };

            _context.Merchants.Add(merchant);
            await _context.SaveChangesAsync(cancellation);

            return new CreateMerchantCommandDto
            {
                Success = true,
                Message = "Merchant successfully created"
            };

        }
    }
}