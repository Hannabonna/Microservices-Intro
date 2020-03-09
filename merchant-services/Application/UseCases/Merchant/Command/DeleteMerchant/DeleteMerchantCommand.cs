
using MediatR;

namespace merchant_services.Application.UseCases.Merchant.Command.DeleteMerchant
{
    public class DeleteMerchantCommand : IRequest<DeleteMerchantCommandDto>
    {
        public int Id { get; set; }

        public DeleteMerchantCommand(int id)
        {
            Id = id;
        }
    }
}