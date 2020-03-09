
using System.Threading;
using System.Threading.Tasks;
using merchant_services.Infrastructure.Presistences;
using MediatR;

namespace merchant_services.Application.UseCases.Merchant.Command.DeleteMerchant
{
    public class DeleteMerchantCommandHandler : IRequestHandler<DeleteMerchantCommand, DeleteMerchantCommandDto>
    {
        private readonly MerchantContext _context;

        public DeleteMerchantCommandHandler(MerchantContext context)
        {
            _context = context;
        }

        public async Task<DeleteMerchantCommandDto> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Merchants.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Merchants.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteMerchantCommandDto { Message = "Successfull", Success = true };
        }
    }
}